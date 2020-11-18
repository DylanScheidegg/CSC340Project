using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DylanScheideggSocialMediaProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace DylanScheideggSocialMediaProject.Controllers
{
    public class GroupController : Controller
    {
        // User context
        private UserContext context { get; set; }

        // User context and GroupController connected
        public GroupController(UserContext ctx)
        {
            context = ctx;
        }

        // Grabbing the information for the table and putting it in GroupId order
        public IActionResult Index()
        {
            var groups = context.Groups.OrderBy(e => e.GroupID).ToList();
            return View(groups);
        }

        // Gets data for the add group page
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.uUser = context.Users.OrderBy(t => t.UserID).ToList();
            // Creates new group
            return View("Edit", new Group());
        }

        // Gets data for the edit group page
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.uUser = context.Users.OrderBy(t => t.UserID).ToList();
            var gro = context.Groups.Find(id);
            return View(gro);
        }

        // Displays data for the edit group page
        [HttpPost]
        public IActionResult Edit(Group gro)
        {
            if (ModelState.IsValid)
            {
                if (gro.GroupID == 0)
                {
                    // adding
                    context.Groups.Add(gro);
                }
                else
                {
                    // updating
                    context.Groups.Update(gro);
                }
                // change DB
                context.SaveChanges();
                return RedirectToAction("Index", "Group");
            }
            else
            {
                // group error
                ViewBag.Action = (gro.GroupID == 0) ? "Add" : "Edit";
                ViewBag.uUser = context.Users.OrderBy(t => t.UserID).ToList();
                return View(gro);
            }
        }

        // Gets data for the Delete group page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // find group to be deleted
            var gro = context.Groups.Find(id);
            return View(gro);
        }

        // Displays data for the Delete Group page
        [HttpPost]
        public IActionResult Delete(Group gro)
        {
            // Loop through each user
            foreach (var x in context.Users)
            {
                // Check if any user is connected to the Group that is about to be deleted
                if (x.UserGroupID == gro.GroupID)
                {
                    // Sets user GroupID to null
                    x.UserGroupID = null;
                    // Updates user context
                    context.Users.Update(x);
                }
            }
            // deletes and updates db
            context.Groups.Remove(gro);
            context.SaveChanges();
            return RedirectToAction("Index", "Group");
        }
    }
}

