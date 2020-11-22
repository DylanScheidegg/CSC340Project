using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DylanScheideggSocialMediaProject.Models
{
    public class UserContext : DbContext
    {
        // Creates an instance of the usercontext context
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        { }

        // Collection of posts
        public DbSet<Post> Posts { get; set; }
        // Collection of users
        public DbSet<User> Users { get; set; }
        // Collection of group
        public DbSet<Group> Groups { get; set; }

        // Creating data for the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 3 Users are initialized into the database
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    FName = "Dylan",
                    LName = "Scheidegg",
                    Password = "CSharpIsFun",
                    Gender = "Male",
                    DOB = new DateTime(1999, 06, 19),
                    Address = "123 Sesame St",
                    City = "Philadelphia",
                    State = "PA",
                    Zipcode = 19123,
                    Country = "USA",
                    UserGroupID = 1
                },
                new User
                {
                    UserID = 2,
                    FName = "Michael",
                    LName = "Scott",
                    Password = "MScott",
                    Gender = "Male",
                    DOB = new DateTime(1980, 03, 15),
                    Address = "42 Kellum Court",
                    City = "Scranton",
                    State = "PA",
                    Zipcode = 18510,
                    Country = "USA",
                    UserGroupID = null
                },
                new User
                {
                    UserID = 3,
                    FName = "Bill",
                    LName = "Gates",
                    Password = "BILLISTHEBEST",
                    Gender = "Male",
                    DOB = new DateTime(1955, 10, 28),
                    Address = "1835 73rd Ave NE",
                    City = "Medina",
                    State = "WA",
                    Zipcode = 98039,
                    Country = "USA",
                    UserGroupID = 2
                });

            // 5 Posts are initialized into the database
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    PostID = 1,
                    UserPostID = 1,
                    Data = "Gotta love this class",
                    Image = "https://miro.medium.com/max/680/0*whPt9R9BXJ5xotoh.jpg",
                    PostTime = new DateTime(2020, 09, 20)
                },
                new Post
                {
                    PostID = 2,
                    UserPostID = 2,
                    Data = "Sometimes I'll start a sentence and I don't even know where it's going. I just hope I find it along the way.",
                    Image = "",
                    PostTime = new DateTime(2020, 09, 20)
                },
                new Post
                {
                    PostID = 3,
                    UserPostID = 1,
                    Data = "Top of the morning to ya laddies - Jack",
                    Image = "https://img.huffingtonpost.com/asset/5e0f68ec2500003b1998fb2e.jpeg?cache=YqiWjN9UVt&ops=1778_1000",
                    PostTime = new DateTime(2020, 12, 20)
                },
                new Post
                {
                    PostID = 4,
                    UserPostID = 1,
                    Data = "Somebody once told me the world is gonna roll me I ain't the sharpest tool in the shed She was looking kind of dumb with her finger and her thumb In the shape of an 'L' on her forehead",
                    Image = "https://img1.looper.com/img/gallery/things-only-adults-notice-in-shrek/intro-1573597941.jpg",
                    PostTime = new DateTime(2018, 06, 10)
                },
                new Post
                {
                    PostID = 5,
                    UserPostID = 2,
                    Data = "You know what they say. Fool me once, strike one, but fool me twice...strike three.",
                    Image = "https://cdn.costumewall.com/wp-content/uploads/2018/09/date-mike.jpg",
                    PostTime = new DateTime(2020, 09, 20)
                });

            // 2 Groups are initialized into the database
            modelBuilder.Entity<Group>().HasData(
                new Group
                {
                    GroupID = 1,
                    Name = "Dunder",
                    LeaderID = 2,
                    CreationDate = new DateTime(2020, 10, 29)
                },
                new Group
                {
                    GroupID = 2,
                    Name = "GitHub",
                    LeaderID = 3,
                    CreationDate = new DateTime(2020, 10, 29)
                });
        }
    }
}