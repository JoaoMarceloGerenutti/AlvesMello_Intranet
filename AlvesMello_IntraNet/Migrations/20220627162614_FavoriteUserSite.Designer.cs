﻿// <auto-generated />
using System;
using AlvesMello_IntraNet.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlvesMello_IntraNet.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220627162614_FavoriteUserSite")]
    partial class FavoriteUserSite
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AlvesMello_IntraNet.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AlvesMello_IntraNet.Models.FavoriteUserSite", b =>
                {
                    b.Property<int>("FavoriteUserSiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FavoriteUserSiteId"), 1L, 1);

                    b.Property<string>("FavoriteUserId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("FavoriteUserSiteId");

                    b.HasIndex("SiteId");

                    b.ToTable("FavoriteUserSites");
                });

            modelBuilder.Entity("AlvesMello_IntraNet.Models.Site", b =>
                {
                    b.Property<int>("SiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SiteId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SiteUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("SiteId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("AlvesMello_IntraNet.Models.FavoriteUserSite", b =>
                {
                    b.HasOne("AlvesMello_IntraNet.Models.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId");

                    b.Navigation("Site");
                });

            modelBuilder.Entity("AlvesMello_IntraNet.Models.Site", b =>
                {
                    b.HasOne("AlvesMello_IntraNet.Models.Category", "Category")
                        .WithMany("Sites")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AlvesMello_IntraNet.Models.Category", b =>
                {
                    b.Navigation("Sites");
                });
#pragma warning restore 612, 618
        }
    }
}
