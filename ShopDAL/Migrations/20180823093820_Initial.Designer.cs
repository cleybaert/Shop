﻿// <auto-generated />
using DaycareDAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DaycareDAL.Migrations
{
    [DbContext(typeof(DaycareContext))]
    [Migration("20180823093820_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DaycareModel.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("AccountId");

                    b.HasIndex("AddressId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new { AccountId = 1, AddressId = 1, FirstName = "Jos", LastName = "Baert" },
                        new { AccountId = 2, AddressId = 1, FirstName = "Hanelore", LastName = "Baert" }
                    );
                });

            modelBuilder.Entity("DaycareModel.Entities.AccountRelation", b =>
                {
                    b.Property<int>("AccountRelationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ObjectId");

                    b.Property<int>("RelationType");

                    b.Property<int>("SubjectId");

                    b.HasKey("AccountRelationId");

                    b.HasIndex("ObjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("AccountRelations");

                    b.HasData(
                        new { AccountRelationId = 1, ObjectId = 2, RelationType = 0, SubjectId = 1 }
                    );
                });

            modelBuilder.Entity("DaycareModel.Entities.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId");

                    b.Property<int>("Number");

                    b.Property<string>("Street");

                    b.Property<int>("SubNumber");

                    b.HasKey("AddressId");

                    b.HasIndex("CityId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new { AddressId = 1, CityId = 1, Number = 35, Street = "Hundelgemsesteenweg", SubNumber = 4 }
                    );
                });

            modelBuilder.Entity("DaycareModel.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code");

                    b.Property<string>("Name");

                    b.HasKey("CityId");

                    b.ToTable("Cities");

                    b.HasData(
                        new { CityId = 1, Code = 9820, Name = "Merelbeke" }
                    );
                });

            modelBuilder.Entity("DaycareModel.Entities.Account", b =>
                {
                    b.HasOne("DaycareModel.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DaycareModel.Entities.AccountRelation", b =>
                {
                    b.HasOne("DaycareModel.Entities.Account", "Subject")
                        .WithMany("SubjectRelations")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DaycareModel.Entities.Account", "Object")
                        .WithMany("ObjectRelations")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DaycareModel.Entities.Address", b =>
                {
                    b.HasOne("DaycareModel.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
