using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DylanScheideggSocialMediaProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaderID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPostID = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zipcode = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPostID = table.Column<int>(type: "int", nullable: true),
                    UserGroupID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Groups_UserGroupID",
                        column: x => x.UserGroupID,
                        principalTable: "Groups",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Posts_UserPostID",
                        column: x => x.UserPostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupID", "CreationDate", "LeaderID", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Dunder" },
                    { 2, new DateTime(2020, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "GitHub" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "Data", "Image", "PostTime", "UserPostID" },
                values: new object[,]
                {
                    { 1, "Gotta love this class", "https://miro.medium.com/max/680/0*whPt9R9BXJ5xotoh.jpg", new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Sometimes I'll start a sentence and I don't even know where it's going. I just hope I find it along the way.", "", new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "Top of the morning to ya laddies - Jack", "https://img.huffingtonpost.com/asset/5e0f68ec2500003b1998fb2e.jpeg?cache=YqiWjN9UVt&ops=1778_1000", new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, "Somebody once told me the world is gonna roll me I ain't the sharpest tool in the shed She was looking kind of dumb with her finger and her thumb In the shape of an 'L' on her forehead", "https://img1.looper.com/img/gallery/things-only-adults-notice-in-shrek/intro-1573597941.jpg", new DateTime(2018, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, "You know what they say. Fool me once, strike one, but fool me twice...strike three.", "https://cdn.costumewall.com/wp-content/uploads/2018/09/date-mike.jpg", new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Address", "City", "Country", "DOB", "FName", "Gender", "LName", "Password", "State", "UserGroupID", "UserPostID", "Zipcode" },
                values: new object[] { 2, "42 Kellum Court", "Scranton", "USA", new DateTime(1980, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "Male", "Scott", "MScott", "PA", null, null, 18510 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Address", "City", "Country", "DOB", "FName", "Gender", "LName", "Password", "State", "UserGroupID", "UserPostID", "Zipcode" },
                values: new object[] { 1, "123 Sesame St", "Philadelphia", "USA", new DateTime(1999, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dylan", "Male", "Scheidegg", "CSharpIsFun", "PA", 1, null, 19123 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Address", "City", "Country", "DOB", "FName", "Gender", "LName", "Password", "State", "UserGroupID", "UserPostID", "Zipcode" },
                values: new object[] { 3, "1835 73rd Ave NE", "Medina", "USA", new DateTime(1955, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", "Male", "Gates", "BILLISTHEBEST", "WA", 2, null, 98039 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserGroupID",
                table: "Users",
                column: "UserGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserPostID",
                table: "Users",
                column: "UserPostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
