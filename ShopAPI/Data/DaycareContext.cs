using Shop.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DaycareContext : IdentityDbContext<DaycareIdentityUser>
    {
        public DaycareContext(DbContextOptions<DaycareContext> options): base(options)
        {
        }

        //public DbSet<Account> Accounts { get; set; }
    }
}
