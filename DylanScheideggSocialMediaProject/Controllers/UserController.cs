using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DylanScheideggSocialMediaProject.Models;

namespace DylanScheideggSocialMediaProject.Controllers
{
    public class UserController : Controller
    {
        // user context
        private UserContext context { get; set; }

        // User context and usercontroller connected
        public UserController(UserContext ctx)
        {
            context = ctx;
        }

        // Grabbing the information for the table and putting it in userid order
        public IActionResult Index()
        {
            var users = context.Users.OrderBy(e => e.UserID).ToList();
            return View(users);
        }

        // Gets data for the add User page
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.uGroup = context.Groups.OrderBy(t => t.GroupID).ToList();
            return View("Edit", new User());
        }

        // Gets data for the edit User page
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.uGroup = context.Groups.OrderBy(t => t.GroupID).ToList();
            var usr = context.Users.Find(id);
            return View(usr);
        }

        // Displays data for the edit User page
        [HttpPost]
        public IActionResult Edit(User usr)
        {
            if (ModelState.IsValid)
            {
                if (usr.UserID == 0)
                {
                    // adding
                    context.Users.Add(usr);
                }
                else
                {
                    // updating
                    context.Users.Update(usr);
                }

                context.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            else
            {
                // user error
                ViewBag.Action = (usr.UserID == 0) ? "Add" : "Edit";
                ViewBag.uGroup = context.Groups.OrderBy(t => t.GroupID).ToList();
                return View(usr);
            }
        }

        // Gets data for the Delete User page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // find user to be deleted
            var usr = context.Users.Find(id);
            return View(usr);
        }

        // Displays data for the Delete user page
        [HttpPost]
        public IActionResult Delete(User usr)
        {
            context.Users.Remove(usr);
            context.SaveChanges();
            return RedirectToAction("Index", "User");
        }
    }
}
