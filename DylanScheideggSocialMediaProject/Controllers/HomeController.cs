using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DylanScheideggSocialMediaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DylanScheideggSocialMediaProject.Controllers
{
    public class HomeController : Controller
    {
        // User context
        private UserContext context { get; set; }

        // User context and GroupController connected
        public HomeController(UserContext ctx)
        {
            context = ctx;
        }

        // Display the basic user information page
        public IActionResult Index()
        {
            var listings = context.Users.Include(u => u.UserPost).Include(u => u.UserGroup).OrderBy(u => u.UserID).ToList();
            return View(listings);
        }

        // Display privacy page
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
