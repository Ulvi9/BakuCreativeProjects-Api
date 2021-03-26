﻿// <auto-generated />
using System;
using BakuCreativeProjects.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BakuCreativeProjects.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BakuCreativeProjects.Models.ChildCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("ChildCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sport",
                            SubCategoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sport",
                            SubCategoryId = 3
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sport",
                            SubCategoryId = 5
                        },
                        new
                        {
                            Id = 4,
                            Name = "Klassik",
                            SubCategoryId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Klassik",
                            SubCategoryId = 3
                        },
                        new
                        {
                            Id = 6,
                            Name = "Klassik",
                            SubCategoryId = 5
                        },
                        new
                        {
                            Id = 7,
                            Name = "Saat",
                            SubCategoryId = 2
                        },
                        new
                        {
                            Id = 8,
                            Name = "Saat",
                            SubCategoryId = 4
                        },
                        new
                        {
                            Id = 9,
                            Name = "Saat",
                            SubCategoryId = 6
                        });
                });

            modelBuilder.Entity("BakuCreativeProjects.Models.MainCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MainCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kisi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Qadin"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Usaq"
                        });
                });

            modelBuilder.Entity("BakuCreativeProjects.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("BakuCreativeProjects.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChildCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChildCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BakuCreativeProjects.Models.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MainCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MainCategoryId");

                    b.ToTable("SubCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MainCategoryId = 1,
                            Name = "Ayaqqabi"
                        },
                        new
                        {
                            Id = 2,
                            MainCategoryId = 1,
                            Name = "Aksesuar"
                        },
                        new
                        {
                            Id = 3,
                            MainCategoryId = 2,
                            Name = "Ayaqqabi"
                        },
                        new
                        {
                            Id = 4,
                            MainCategoryId = 2,
                            Name = "Aksesuar"
                        },
                        new
                        {
                            Id = 5,
                            MainCategoryId = 3,
                            Name = "Ayaqqabi"
                        },
                        new
                        {
                            Id = 6,
                            MainCategoryId = 3,
                            Name = "Aksesuar"
                        });
                });

            modelBuilder.Entity("BakuCreativeProjects.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BakuCreativeProjects.Models.ChildCategory", b =>
                {
                    b.HasOne("BakuCreativeProjects.Models.SubCategory", "SubCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("BakuCreativeProjects.Models.Photo", b =>
                {
                    b.HasOne("BakuCreativeProjects.Models.Product", "Product")
                        .WithMany("Photos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BakuCreativeProjects.Models.Product", b =>
                {
                    b.HasOne("BakuCreativeProjects.Models.ChildCategory", "ChildCategory")
                        .WithMany("Products")
                        .HasForeignKey("ChildCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChildCategory");
                });

            modelBuilder.Entity("BakuCreativeProjects.Models.SubCategory", b =>
                {
                    b.HasOne("BakuCreativeProjects.Models.MainCategory", "MainCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("MainCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainCategory");
                });

            modelBuilder.Entity("BakuCreativeProjects.Models.ChildCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BakuCreativeProjects.Models.MainCategory", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("BakuCreativeProjects.Models.Product", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("BakuCreativeProjects.Models.SubCategory", b =>
                {
                    b.Navigation("ChildCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
