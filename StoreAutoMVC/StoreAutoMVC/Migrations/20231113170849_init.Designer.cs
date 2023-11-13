﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreAutoMVC.Entity;

#nullable disable

namespace StoreAutoMVC.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20231113170849_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StoreAutoMVC.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NameBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProducingCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NameBrand = "Mercedes-Benz",
                            ProducingCountry = "Germany"
                        },
                        new
                        {
                            Id = 2,
                            NameBrand = "Audi",
                            ProducingCountry = "Germany"
                        });
                });

            modelBuilder.Entity("StoreAutoMVC.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DriverType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("EngineCapacity")
                        .HasColumnType("real");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceEquipment")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Equipments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DriverType = "All-wheel drive",
                            EngineCapacity = 3f,
                            FuelType = "Gasoline",
                            ModelId = 1,
                            ModelYear = 2020,
                            PriceEquipment = 250000m
                        },
                        new
                        {
                            Id = 2,
                            DriverType = "All-wheel drive",
                            EngineCapacity = 2f,
                            FuelType = "Gasoline",
                            ModelId = 2,
                            ModelYear = 2021,
                            PriceEquipment = 200000m
                        },
                        new
                        {
                            Id = 3,
                            DriverType = "Rear wheel drive",
                            EngineCapacity = 3f,
                            FuelType = "Diesel",
                            ModelId = 3,
                            ModelYear = 2019,
                            PriceEquipment = 210000m
                        });
                });

            modelBuilder.Entity("StoreAutoMVC.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BodyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Guarantee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BodyType = "Crossover",
                            BrandId = 1,
                            Guarantee = "5 years",
                            NameModel = "GLS"
                        },
                        new
                        {
                            Id = 2,
                            BodyType = "Universal",
                            BrandId = 2,
                            Guarantee = "6 years",
                            NameModel = "A6"
                        },
                        new
                        {
                            Id = 3,
                            BodyType = "Sedan",
                            BrandId = 1,
                            Guarantee = "10 years",
                            NameModel = "E-class"
                        });
                });

            modelBuilder.Entity("StoreAutoMVC.Models.Equipment", b =>
                {
                    b.HasOne("StoreAutoMVC.Models.Model", "Model")
                        .WithMany("Equipments")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("StoreAutoMVC.Models.Model", b =>
                {
                    b.HasOne("StoreAutoMVC.Models.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("StoreAutoMVC.Models.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("StoreAutoMVC.Models.Model", b =>
                {
                    b.Navigation("Equipments");
                });
#pragma warning restore 612, 618
        }
    }
}
