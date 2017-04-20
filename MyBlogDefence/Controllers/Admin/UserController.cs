using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyBlogDefence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogDefence.Controllers.Admin
{
    public class UserController : Controller
    {
        //
        // GET: User/List
        public ActionResult List()
        {
            using (var database = new BlogDbContext())
            {
                var users = database.Users.ToList();

                var admins = GetAdminUserNames(users, database);
                ViewBag.Admins = admins;

                return View(users);
            }
        }
        //
        // GET: User
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        private HashSet<string> GetAdminUserNames(List<ApplicationUser>users, BlogDbContext conext)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(conext));

            var admins = new HashSet<string>();

            foreach (var user in users)
            {
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    admins.Add(user.UserName);
                }
            }

            return admins;
        }

        
    }
}