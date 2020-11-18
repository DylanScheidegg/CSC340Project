using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DylanScheideggSocialMediaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DylanScheideggSocialMediaProject.Controllers
{
    public class PostController : Controller
    {
        // User context
        private UserContext context { get; set; }

        // User context and PostController connected
        public PostController(UserContext ctx)
        {
            context = ctx;
        }

        // Grabbing the information for the table and putting it in PostId order
        public IActionResult Index()
        {
            var posts = context.Posts.OrderBy(e => e.PostID).ToList();
            return View(posts);
        }

        // Gets data for the add post page
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.uUser = context.Users.OrderBy(t => t.UserID).ToList();
            return View("Edit", new Post()); // creates new post
        }

        // Gets data for the edit post page
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.uUser = context.Users.OrderBy(t => t.UserID).ToList();
            var pos = context.Posts.Find(id);
            return View(pos);
        }

        // Displays data for the edit post page
        [HttpPost]
        public IActionResult Edit(Post pos)
        {
            if (ModelState.IsValid)
            {
                if (pos.PostID == 0)
                {
                    // adding
                    context.Posts.Add(pos);
                }
                else
                {
                    // updating
                    context.Posts.Update(pos);
                }
                // update DB
                context.SaveChanges();
                return RedirectToAction("Index", "Post");
            }
            else
            {
                // post error
                ViewBag.Action = (pos.PostID == 0) ? "Add" : "Edit";
                ViewBag.uUser = context.Users.OrderBy(t => t.UserID).ToList();
                return View(pos);
            }
        }

        // Gets data for the Delete post page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // find post to be deleted
            var pos = context.Posts.Find(id);
            return View(pos);
        }

        // Displays data for the Delete post page
        [HttpPost]
        public IActionResult Delete(Post pos)
        {
            context.Posts.Remove(pos);
            context.SaveChanges();
            return RedirectToAction("Index", "Post");
        }

    }
}

