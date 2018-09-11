using Daycare.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DaycareDAL
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(new City()
            {
                CityId = 1,
                Code = 9820,
                Name = "Merelbeke"
            });
            modelBuilder.Entity<Address>().HasData(new
            {
                AddressId = 1,
                CityId = 1,
                Number = 35,
                SubNumber = 4,
                Street = "Hundelgemsesteenweg"
            });

            // https://stackoverflow.com/questions/5828394/entity-framework-4-1-inverseproperty-attribute-and-foreignkey
            modelBuilder.Entity<AccountRelation>()
                 .HasOne(ar => ar.Object)
                 .WithMany(o => o.ObjectRelations)
                 .HasForeignKey(ar => ar.SubjectId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccountRelation>()
                 .HasOne(ar => ar.Subject)
                 .WithMany(o => o.SubjectRelations)
                 .HasForeignKey(ar => ar.ObjectId)
                 .OnDelete(DeleteBehavior.Restrict);            

            modelBuilder.Entity<Account>().HasData(new
            {
                AccountId = 1,
                AddressId = 1,
                FirstName = "Jos",
                LastName = "Baert"
            });

            modelBuilder.Entity<Account>().HasData(new
            {
                AccountId = 2,
                AddressId = 1,
                FirstName = "Hanelore",
                LastName = "Baert"
            });

            modelBuilder.Entity<AccountRelation>().HasData(new
            {
                AccountRelationId = 1,
                SubjectId = 1,
                ObjectId = 2,
                RelationType = AccountRelation.AccountRelationType.Principal
            });
        }
    }
}
