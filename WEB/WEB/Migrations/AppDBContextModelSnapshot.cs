﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEB.Models;

#nullable disable

namespace WEB.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WEB.Entity.BodyType", b =>
                {
                    b.Property<byte>("body_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("body_id"));

                    b.Property<string>("body_name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("body_id");

                    b.ToTable("BodyType");
                });

            modelBuilder.Entity("WEB.Entity.Car", b =>
                {
                    b.Property<short>("car_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("car_id"));

                    b.Property<byte?>("BodyTypebody_id")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("CarTypetype_id")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("Drive_typedrive_id")
                        .HasColumnType("tinyint");

                    b.Property<byte>("body_id")
                        .HasColumnType("tinyint");

                    b.Property<string>("car_name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<byte>("drive_id")
                        .HasColumnType("tinyint");

                    b.Property<byte>("fuel_id")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("fuel_id1")
                        .HasColumnType("tinyint");

                    b.Property<string>("imagepath")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<byte>("num_seats")
                        .HasColumnType("tinyint");

                    b.Property<short>("price")
                        .HasColumnType("smallint");

                    b.Property<byte>("transmission_id")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("transmission_id1")
                        .HasColumnType("tinyint");

                    b.Property<byte>("type_id")
                        .HasColumnType("tinyint");

                    b.HasKey("car_id");

                    b.HasIndex("BodyTypebody_id");

                    b.HasIndex("CarTypetype_id");

                    b.HasIndex("Drive_typedrive_id");

                    b.HasIndex("fuel_id1");

                    b.HasIndex("transmission_id1");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("WEB.Entity.CarType", b =>
                {
                    b.Property<byte>("type_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("type_id"));

                    b.Property<string>("car_type_name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(10)");

                    b.HasKey("type_id");

                    b.ToTable("CarType");
                });

            modelBuilder.Entity("WEB.Entity.Drive_type", b =>
                {
                    b.Property<byte>("drive_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("drive_id"));

                    b.Property<string>("drive_name")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)");

                    b.HasKey("drive_id");

                    b.ToTable("Drive_type");
                });

            modelBuilder.Entity("WEB.Entity.Fuel", b =>
                {
                    b.Property<byte>("fuel_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("fuel_id"));

                    b.Property<string>("fuel_name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("fuel_id");

                    b.ToTable("Fuel");
                });

            modelBuilder.Entity("WEB.Entity.Order", b =>
                {
                    b.Property<int>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("order_id"));

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte?>("Reservationstatus_id")
                        .HasColumnType("tinyint");

                    b.Property<short>("car_id")
                        .HasColumnType("smallint");

                    b.Property<short?>("car_id1")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("end_day")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("start_day")
                        .HasColumnType("DateTime");

                    b.Property<byte>("status_id")
                        .HasColumnType("tinyint");

                    b.Property<int>("total_price")
                        .HasColumnType("int");

                    b.HasKey("order_id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("Reservationstatus_id");

                    b.HasIndex("car_id1");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WEB.Entity.Reservation", b =>
                {
                    b.Property<byte>("status_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("status_id"));

                    b.Property<string>("status_name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(20)");

                    b.HasKey("status_id");

                    b.ToTable("Res_status");
                });

            modelBuilder.Entity("WEB.Entity.Transmission", b =>
                {
                    b.Property<byte>("transmission_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("transmission_id"));

                    b.Property<string>("transmission_name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("transmission_id");

                    b.ToTable("Transmission");
                });

            modelBuilder.Entity("WEB.Models.CarOrder", b =>
                {
                    b.Property<short>("car_id")
                        .HasColumnType("smallint");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("body_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("car_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("car_type_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("drive_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("end_day")
                        .HasColumnType("datetime2");

                    b.Property<string>("fuel_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagepath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("num_seats")
                        .HasColumnType("tinyint");

                    b.Property<int>("order_id")
                        .HasColumnType("int");

                    b.Property<short>("price")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("start_day")
                        .HasColumnType("datetime2");

                    b.Property<byte>("status_id")
                        .HasColumnType("tinyint");

                    b.Property<int>("total_price")
                        .HasColumnType("int");

                    b.Property<string>("transmission_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("car_id");

                    b.ToTable((string)null);

                    b.ToView("Car_Order", (string)null);
                });

            modelBuilder.Entity("WEB.Models.Cars", b =>
                {
                    b.Property<short>("car_id")
                        .HasColumnType("smallint");

                    b.Property<string>("body_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("car_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("car_type_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("drive_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fuel_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagepath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("num_seats")
                        .HasColumnType("tinyint");

                    b.Property<short>("price")
                        .HasColumnType("smallint");

                    b.Property<string>("transmission_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("car_id");

                    b.ToTable((string)null);

                    b.ToView("CarView", (string)null);
                });

            modelBuilder.Entity("WEB.Entity.AppUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("AppUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WEB.Entity.Car", b =>
                {
                    b.HasOne("WEB.Entity.BodyType", null)
                        .WithMany("Cars")
                        .HasForeignKey("BodyTypebody_id");

                    b.HasOne("WEB.Entity.CarType", null)
                        .WithMany("Cars")
                        .HasForeignKey("CarTypetype_id");

                    b.HasOne("WEB.Entity.Drive_type", null)
                        .WithMany("Cars")
                        .HasForeignKey("Drive_typedrive_id");

                    b.HasOne("WEB.Entity.Fuel", null)
                        .WithMany("Cars")
                        .HasForeignKey("fuel_id1");

                    b.HasOne("WEB.Entity.Transmission", null)
                        .WithMany("Cars")
                        .HasForeignKey("transmission_id1");
                });

            modelBuilder.Entity("WEB.Entity.Order", b =>
                {
                    b.HasOne("WEB.Entity.AppUser", "AppUser")
                        .WithMany("Orders")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WEB.Entity.Reservation", null)
                        .WithMany("Orders")
                        .HasForeignKey("Reservationstatus_id");

                    b.HasOne("WEB.Entity.Car", null)
                        .WithMany("Orders")
                        .HasForeignKey("car_id1");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("WEB.Entity.BodyType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("WEB.Entity.Car", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WEB.Entity.CarType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("WEB.Entity.Drive_type", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("WEB.Entity.Fuel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("WEB.Entity.Reservation", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WEB.Entity.Transmission", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("WEB.Entity.AppUser", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
