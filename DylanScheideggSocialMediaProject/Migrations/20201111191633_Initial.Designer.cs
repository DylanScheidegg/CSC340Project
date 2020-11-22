﻿// <auto-generated />
using System;
using DylanScheideggSocialMediaProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DylanScheideggSocialMediaProject.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20201111191633_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DylanScheideggSocialMediaProject.Models.Group", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LeaderID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupID");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupID = 1,
                            CreationDate = new DateTime(2020, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeaderID = 2,
                            Name = "Dunder"
                        },
                        new
                        {
                            GroupID = 2,
                            CreationDate = new DateTime(2020, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeaderID = 3,
                            Name = "GitHub"
                        });
                });

            modelBuilder.Entity("DylanScheideggSocialMediaProject.Models.Post", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserPostID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("PostID");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostID = 1,
                            Data = "Gotta love this class",
                            Image = "https://miro.medium.com/max/680/0*whPt9R9BXJ5xotoh.jpg",
                            PostTime = new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserPostID = 1
                        },
                        new
                        {
                            PostID = 2,
                            Data = "Sometimes I'll start a sentence and I don't even know where it's going. I just hope I find it along the way.",
                            Image = "",
                            PostTime = new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserPostID = 2
                        },
                        new
                        {
                            PostID = 3,
                            Data = "Top of the morning to ya laddies - Jack",
                            Image = "https://img.huffingtonpost.com/asset/5e0f68ec2500003b1998fb2e.jpeg?cache=YqiWjN9UVt&ops=1778_1000",
                            PostTime = new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserPostID = 1
                        },
                        new
                        {
                            PostID = 4,
                            Data = "Somebody once told me the world is gonna roll me I ain't the sharpest tool in the shed She was looking kind of dumb with her finger and her thumb In the shape of an 'L' on her forehead",
                            Image = "https://img1.looper.com/img/gallery/things-only-adults-notice-in-shrek/intro-1573597941.jpg",
                            PostTime = new DateTime(2018, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserPostID = 1
                        },
                        new
                        {
                            PostID = 5,
                            Data = "You know what they say. Fool me once, strike one, but fool me twice...strike three.",
                            Image = "https://cdn.costumewall.com/wp-content/uploads/2018/09/date-mike.jpg",
                            PostTime = new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserPostID = 2
                        });
                });

            modelBuilder.Entity("DylanScheideggSocialMediaProject.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserGroupID")
                        .HasColumnType("int");

                    b.Property<int?>("UserPostID")
                        .HasColumnType("int");

                    b.Property<int>("Zipcode")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.HasIndex("UserGroupID");

                    b.HasIndex("UserPostID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Address = "123 Sesame St",
                            City = "Philadelphia",
                            Country = "USA",
                            DOB = new DateTime(1999, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FName = "Dylan",
                            Gender = "Male",
                            LName = "Scheidegg",
                            Password = "CSharpIsFun",
                            State = "PA",
                            UserGroupID = 1,
                            Zipcode = 19123
                        },
                        new
                        {
                            UserID = 2,
                            Address = "42 Kellum Court",
                            City = "Scranton",
                            Country = "USA",
                            DOB = new DateTime(1980, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FName = "Michael",
                            Gender = "Male",
                            LName = "Scott",
                            Password = "MScott",
                            State = "PA",
                            Zipcode = 18510
                        },
                        new
                        {
                            UserID = 3,
                            Address = "1835 73rd Ave NE",
                            City = "Medina",
                            Country = "USA",
                            DOB = new DateTime(1955, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FName = "Bill",
                            Gender = "Male",
                            LName = "Gates",
                            Password = "BILLISTHEBEST",
                            State = "WA",
                            UserGroupID = 2,
                            Zipcode = 98039
                        });
                });

            modelBuilder.Entity("DylanScheideggSocialMediaProject.Models.User", b =>
                {
                    b.HasOne("DylanScheideggSocialMediaProject.Models.Group", "UserGroup")
                        .WithMany()
                        .HasForeignKey("UserGroupID");

                    b.HasOne("DylanScheideggSocialMediaProject.Models.Post", "UserPost")
                        .WithMany()
                        .HasForeignKey("UserPostID");

                    b.Navigation("UserGroup");

                    b.Navigation("UserPost");
                });
#pragma warning restore 612, 618
        }
    }
}
