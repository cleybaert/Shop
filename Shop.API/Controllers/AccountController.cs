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

namespace Shop.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly SignInManager<DaycareIdentityUser> signInManager;
        private readonly IMapper mapper;

        public AccountController(IConfiguration config,
            SignInManager<DaycareIdentityUser> signInManager,
            IMapper mapper)
        {
            this.config = config;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTokenAsync([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await signInManager.UserManager.FindByEmailAsync(model.UserName);
                if (user != null)
                {
                    var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                    if (result == Microsoft.AspNetCore.Identity.SignInResult.Success)
                    {
                        // Create token
                        var claims = new[]
                        {
                        new Claim(JwtRegisteredClaimNames.Sub, model.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, new Guid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, model.UserName)                        
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

                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        };

                        return Created("", results);
                    }
                }
            }

            return BadRequest();
        }

        [HttpGet]   
        [Authorize]
        public async Task<ActionResult> GetAsync()
        {
            var user = await signInManager.UserManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var accountViewModel = mapper.Map<AccountViewModel>(user);
                return Ok(accountViewModel);
            }
            return BadRequest("Failed to get account");
        }

        [HttpGet]
        [Authorize]
        [Route("Overview")]
        public async Task<ActionResult> Overview()
        {
            var overviewViewModel = mapper.Map<IEnumerable<AccountViewModel>>(signInManager.UserManager.Users);
            return Ok(overviewViewModel);
        }
    }
}