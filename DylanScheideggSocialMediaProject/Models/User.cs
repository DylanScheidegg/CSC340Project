using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DylanScheideggSocialMediaProject.Models
{
    public class User
    {
        // User ID PK
        public int UserID { get; set; }
        [Required(ErrorMessage = "First name must be entered")]
        // User first name
        public string FName { get; set; }
        // User last name
        [Required(ErrorMessage = "Last name must be entered")]
        public string LName { get; set; }
        // User password
        [Required(ErrorMessage = "Password must be entered")]
        public string Password { get; set; }
        // User gender
        [Required(ErrorMessage = "Gender must be entered")]
        public string Gender { get; set; }
        // User date of birth
        [Required(ErrorMessage = "Date of Birth must be entered")]
        public DateTime DOB { get; set; }
        // User address
        public string Address { get; set; }
        // User  city
        public string City { get; set; }
        // User state
        public string State { get; set; }
        // User zipcode
        public int Zipcode { get; set; }
        // User country
        public string Country { get; set; }


        // Post foreign key
        public int? UserPostID { get; set; }
        public Post UserPost { get; set; }

        // Group foreign key
        public int? UserGroupID { get; set; }
        public Group UserGroup { get; set; }


        // User context
        private UserContext context { get; set; }
        // Finds which group the user is in
        public string GroupFind()
        {
            // Default value to show the group doesnt exist
            string group = "No Group/Group Deleted";
            // Loop through all groups to find which ID matches the one the user has
            foreach (var x in context.Groups)
            {
                if (UserGroupID == x.GroupID)
                {
                    group = x.Name;
                }
            }
            // Returns the group string with name
            return group;
        }

        // Counts the occurrences in post where the userid matches the userid
        public int TotalPost()
        {
            // Default count value
            int Cnt = 0;
            // Loop through all of the posts to find matching ids
            foreach (var x in context.Posts)
            {
                if (UserID == x.UserPostID)
                {
                    // Increment count
                    Cnt++;
                }
            }
            // Returns the Cnt string with name
            return Cnt;
        }

        // User slug for the URL
        public string Slug => FName?.ToLower() + '-' + LName?.Replace(' ', '-').ToLower();

    }
}