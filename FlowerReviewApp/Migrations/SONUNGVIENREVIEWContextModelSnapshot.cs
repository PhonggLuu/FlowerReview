﻿// <auto-generated />
using System;
using FlowerReviewApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlowerReviewApp.Migrations
{
    [DbContext(typeof(SONUNGVIENREVIEWContext))]
    partial class SONUNGVIENREVIEWContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FlowerReviewApp.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.DetailedProduct", b =>
                {
                    b.Property<int>("DetailedProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailedProductId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DetailedProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("DetailedProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("DetailedProducts");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.DetailedProductOwner", b =>
                {
                    b.Property<int>("DetailedProductId")
                        .HasColumnType("int")
                        .HasColumnName("DetailedProductID");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int")
                        .HasColumnName("OwnerID");

                    b.HasKey("DetailedProductId", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("DetailedProductOwner", (string)null);
                });

            modelBuilder.Entity("FlowerReviewApp.Models.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OwnerId"), 1L, 1);

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OwnerId");

                    b.HasIndex("CountryID");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"), 1L, 1);

                    b.Property<int?>("DetailedProductId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("ReviewerId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewId");

                    b.HasIndex("DetailedProductId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.Reviewer", b =>
                {
                    b.Property<int>("ReviewerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewerId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewerId");

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.DetailedProduct", b =>
                {
                    b.HasOne("FlowerReviewApp.Models.Product", "Product")
                        .WithMany("DetailedProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.DetailedProductOwner", b =>
                {
                    b.HasOne("FlowerReviewApp.Models.DetailedProduct", "DetailedProduct")
                        .WithMany("DetailedProductOwners")
                        .HasForeignKey("DetailedProductId")
                        .IsRequired()
                        .HasConstraintName("FK__DetailedP__Detai__4BAC3F29");

                    b.HasOne("FlowerReviewApp.Models.Owner", "Owner")
                        .WithMany("DetailedProductOwners")
                        .HasForeignKey("OwnerId")
                        .IsRequired()
                        .HasConstraintName("FK__DetailedP__Owner__4AB81AF0");

                    b.Navigation("DetailedProduct");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.Owner", b =>
                {
                    b.HasOne("FlowerReviewApp.Models.Country", "Country")
                        .WithMany("Owners")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.Product", b =>
                {
                    b.HasOne("FlowerReviewApp.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.Review", b =>
                {
                    b.HasOne("FlowerReviewApp.Models.DetailedProduct", null)
                        .WithMany("Reviews")
                        .HasForeignKey("DetailedProductId");

                    b.HasOne("FlowerReviewApp.Models.Reviewer", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.Country", b =>
                {
                    b.Navigation("Owners");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.DetailedProduct", b =>
                {
                    b.Navigation("DetailedProductOwners");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.Owner", b =>
                {
                    b.Navigation("DetailedProductOwners");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.Product", b =>
                {
                    b.Navigation("DetailedProducts");
                });

            modelBuilder.Entity("FlowerReviewApp.Models.Reviewer", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
