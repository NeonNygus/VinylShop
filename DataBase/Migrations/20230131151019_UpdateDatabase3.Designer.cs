﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VinylShop.EfCore;

#nullable disable

namespace VinylShop.Migrations
{
    [DbContext(typeof(EF_DataContext))]
    [Migration("20230131151019_UpdateDatabase3")]
    partial class UpdateDatabase3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VinylShop.EfCore.Customer", b =>
                {
                    b.Property<int>("CustId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustId"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CustId");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("VinylShop.EfCore.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmpId"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("EmpId");

                    b.ToTable("employee");
                });

            modelBuilder.Entity("VinylShop.EfCore.Hire", b =>
                {
                    b.Property<int>("HireId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("HireId"));

                    b.Property<int>("CustId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("VinylId")
                        .HasColumnType("integer");

                    b.HasKey("HireId");

                    b.HasIndex("CustId");

                    b.HasIndex("VinylId");

                    b.ToTable("hire");
                });

            modelBuilder.Entity("VinylShop.EfCore.Vinyl", b =>
                {
                    b.Property<int>("VinylId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VinylId"));

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CatalogueNum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Format")
                        .HasColumnType("integer");

                    b.Property<int>("Genre")
                        .HasColumnType("integer");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("VinylId");

                    b.ToTable("vinyl");
                });

            modelBuilder.Entity("VinylShop.EfCore.Hire", b =>
                {
                    b.HasOne("VinylShop.EfCore.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VinylShop.EfCore.Vinyl", "Vinyl")
                        .WithMany()
                        .HasForeignKey("VinylId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Vinyl");
                });
#pragma warning restore 612, 618
        }
    }
}
