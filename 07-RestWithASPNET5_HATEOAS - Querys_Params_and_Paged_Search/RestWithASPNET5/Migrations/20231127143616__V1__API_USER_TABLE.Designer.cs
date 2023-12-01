﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestWithASPNET5.Context;

#nullable disable

namespace RestWithASPNET5.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231127143616__V1__API_USER_TABLE")]
    partial class _V1__API_USER_TABLE
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestWithASPNET5.Model.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("books");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Author = "Stephen King",
                            Date = new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 89.799999999999997,
                            Title = "IT"
                        },
                        new
                        {
                            Id = 2L,
                            Author = "Stephen Hawking",
                            Date = new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 103.89,
                            Title = "A Brief time history"
                        },
                        new
                        {
                            Id = 3L,
                            Author = "Connan Arthur Doyle",
                            Date = new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 146.72999999999999,
                            Title = "Sherlock Holme - The Baskerville Dog"
                        },
                        new
                        {
                            Id = 4L,
                            Author = "Edgar Alan Poe",
                            Date = new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 75.340000000000003,
                            Title = "The Crow"
                        },
                        new
                        {
                            Id = 5L,
                            Author = "Agatha Christie",
                            Date = new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 91.560000000000002,
                            Title = "A Haunting in Vinice"
                        },
                        new
                        {
                            Id = 6L,
                            Author = "Agatha Christie",
                            Date = new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 78.620000000000005,
                            Title = "A Haunting in Vinice"
                        },
                        new
                        {
                            Id = 7L,
                            Author = "JJ Tolkien",
                            Date = new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 52.32,
                            Title = "The Hobbit"
                        },
                        new
                        {
                            Id = 8L,
                            Author = "Tom Clancy's",
                            Date = new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 58.759999999999998,
                            Title = "Spliter Cell"
                        });
                });

            modelBuilder.Entity("RestWithASPNET5.Model.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.HasKey("Id");

                    b.ToTable("person");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "Recife",
                            FirstName = "Evandro",
                            Gender = "Male",
                            LastName = "Lucas"
                        },
                        new
                        {
                            Id = 2L,
                            Address = "Jaboatão",
                            FirstName = "Jamerson",
                            Gender = "Male",
                            LastName = "Lucas"
                        },
                        new
                        {
                            Id = 3L,
                            Address = "Petrolina",
                            FirstName = "Danielly",
                            Gender = "Femele",
                            LastName = "Oliveira"
                        },
                        new
                        {
                            Id = 4L,
                            Address = "Juazeiro",
                            FirstName = "Lucinea",
                            Gender = "Femele",
                            LastName = "Lucas"
                        },
                        new
                        {
                            Id = 5L,
                            Address = "Recife",
                            FirstName = "Bruno",
                            Gender = "male",
                            LastName = "Lucas"
                        });
                });

            modelBuilder.Entity("RestWithASPNET5.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("full_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("refresh_token");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("refresh_toke_expiry_time");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
