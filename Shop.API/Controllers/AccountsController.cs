using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shop.Data.Entities;
using Shop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shop.API.ViewModels;
using Shop.API.Dto;

namespace Shop.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly SignInManager<DaycareIdentityUser> signInManager;
        private readonly IMapper mapper;

        public AccountsController(
            IConfiguration config,
            SignInManager<DaycareIdentityUser> signInManager,
            IMapper mapper)
        {
            this.config = config;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        private object GenerateToken(string userName)
        {
            // Create token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, new Guid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                config["Tokens:Issuer"],
                config["Tokens:Audience"],
                claims,
                null,
                DateTime.UtcNow.AddMinutes(30),
                creds
                );

            return new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            };
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await signInManager.UserManager.FindByEmailAsync(model.UserName);
                if (user != null)
                {
                    var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                    if (result == Microsoft.AspNetCore.Identity.SignInResult.Success)
                        return Created("", GenerateToken(model.UserName));
                }
            }

            return BadRequest();
        }

        [HttpGet]   
        [Authorize]
        public async Task<IActionResult> GetAsync()
        {
            var user = await signInManager.UserManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var accountViewModel = mapper.Map<AccountViewModel>(user);
                return Ok(accountViewModel);
            }
            return BadRequest("Failed to get account");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await signInManager.UserManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    // user not found
                    // continue with registration process
                    user = mapper.Map<DaycareIdentityUser>(model);

                    try
                    {
                        var registerres = await signInManager.UserManager.CreateAsync(
                            user, model.Password);

                        if (!registerres.Succeeded)
                        {
                            // show or log errors
                        }
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex);
                    }
                }

                // user is found or new user is registered
                // signin this user
                await signInManager.SignInAsync(user, false);

                return Created("", GenerateToken(model.Email));
            }

            return BadRequest();
        }
    }
}