using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DylanScheideggSocialMediaProject.Models
{
    public class Post
    {
        // Post ID PK
        public int PostID { get; set; }
        // UserID who made the Post
        [Required(ErrorMessage = "User must be entered")]
        public int? UserPostID { get; set; }
        // Data for of the post
        [Required(ErrorMessage = "Text must be entered")]
        public string Data { get; set; }
        // Image link
        public string Image { get; set; }
        // Time and date the post was created
        [Required(ErrorMessage = "Date must be entered")]
        public DateTime PostTime { get; set; }


        // User context
        private UserContext context { get; set; }
        // Shows the name of the user who made the post
        public string UserPosted()
        {
            // Default value to show the user doesnt exist
            string UserPost = "User Has been Deleted";
            // Loop through all users to find which ID matches the one who created the post
            foreach (var x in context.Users)
            {
                if (UserPostID == x.UserID)
                {
                    UserPost = x.FName + " " + x.LName;
                }
            }
            // Returns the UserPost string with name
            return UserPost;
        }

        // Post slug for the URL
        public string Slug => UserPosted()?.ToLower();

    }
}