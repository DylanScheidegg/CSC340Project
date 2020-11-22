using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DylanScheideggSocialMediaProject.Models
{
    public class Group
    {
        // Group ID PK
        public int GroupID { get; set; }
        // UserID who made the Group
        [Required(ErrorMessage = "Leader must be entered")]
        public int? LeaderID { get; set; }
        // Name of the group
        [Required(ErrorMessage = "Group name must be entered")]
        public string Name { get; set; }
        // Time and date the group was created
        [Required(ErrorMessage = "Creation date must be entered")]
        public DateTime CreationDate { get; set; }


        // User context
        private UserContext context { get; set; }
        // Shows the name of the user who made the group
        public string UserLeader()
        {
            // Default value to show the user doesnt exist
            string UserGroup = "User has been deleted";
            // Loop through all users to find which ID matches the one who created the group
            foreach (var x in context.Users)
            {
                if (LeaderID == x.UserID)
                {
                    UserGroup = x.FName + " " + x.LName;
                }
            }
            // Returns the UserGroup string with name
            return UserGroup;
        }

        // Group slug for the URL
        public string Slug => Name?.Replace(' ', '-').ToLower();

    }
}