﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SullensShop.Persistence.Context;

#nullable disable

namespace SullensShop.Persistence.Migrations
{
    [DbContext(typeof(SullensShopContext))]
    partial class SullensShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SullensShop.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SullensShop.Domain.Entities.CategoryDetail", b =>
                {
                    b.Property<int>("CategoryDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryDetailId"));

                    b.Property<string>("CategoryDetailName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryDetailId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryDetails");
                });

            modelBuilder.Entity("SullensShop.Domain.Entities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Exception")
                        .HasColumnType("text");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("SullensShop.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryDetailId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("numeric");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryDetailId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SullensShop.Domain.Entities.ProductDetail", b =>
                {
                    b.Property<string>("ProductDetailId")
                        .HasColumnType("text");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductId1")
                        .HasColumnType("integer");

                    b.Property<string>("ProductInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProductDetailId");

                    b.HasIndex("ProductId1");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("SullensShop.Domain.Entities.ProductImage", b =>
                {
                    b.Property<string>("ProductImageId")
                        .HasColumnType("text");

                    b.Property<string>("Image1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image3")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductId1")
                        .HasColumnType("integer");

                    b.HasKey("ProductImageId");

                    b.HasIndex("ProductId1");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("SullensShop.Domain.Entities.CategoryDetail", b =>
                {
                    b.HasOne("SullensShop.Domain.Entities.Category", null)
                        .WithMany("CategoryDetails")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SullensShop.Domain.Entities.Product", b =>
                {
                    b.HasOne("SullensShop.Domain.Entities.CategoryDetail", "CategoryDetail")
                        .WithMany("Products")
                        .HasForeignKey("CategoryDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SullensShop.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("CategoryDetail");
                });

            modelBuilder.Entity("SullensShop.Domain.Entities.ProductDetail", b =>
                {
                    b.HasOne("SullensShop.Domain.Entities.Product", "Product")
                        .WithMany("ProductDetails")
                        .HasForeignKey("ProductId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SullensShop.Domain.Entities.ProductImage", b =>
                {
                    b.HasOne("SullensShop.Domain.Entities.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SullensShop.Domain.Entities.Category", b =>
                {
                    b.Navigation("CategoryDetails");
                });

            modelBuilder.Entity("SullensShop.Domain.Entities.CategoryDetail", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SullensShop.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductDetails");

                    b.Navigation("ProductImages");
                });
#pragma warning restore 612, 618
        }
    }
}
