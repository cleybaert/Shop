using Shop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class Seeder
    {
        private readonly UserManager<DaycareIdentityUser> userManager;
        private readonly DaycareContext daycareContext;

        public Seeder(UserManager<DaycareIdentityUser> userManager,
            DaycareContext daycareContext)
        {
            this.userManager = userManager;
            this.daycareContext = daycareContext;
        }

        public async Task SeedAsync()
        {
            var user = await userManager.FindByEmailAsync("christophe.leybaert@gmail.com");

            if (user == null)
            {
                user = new DaycareIdentityUser()
                {
                    FirstName = "Christophe",
                    LastName = "Leybaert",
                    Email = "christophe.leybaert@gmail.com",
                    UserName = "christophe.leybaert@gmail.com"
                };
                var res = await userManager.CreateAsync(user, "Cl12345!");
                if (res != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to add default user");
                }
            }
        }
    }
}
