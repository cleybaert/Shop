using Daycare.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DaycareDAL.Data
{
    public class DaycareContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<AccountRelation> AccountRelations { get; set; }

        public DaycareContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=CHRISTOPHE\SQLEXPRESS;Initial Catalog=Daycare;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
