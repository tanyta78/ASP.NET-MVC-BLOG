﻿using MyBlogDefence.Migrations;
using MyBlogDefence.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyBlogDefence
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {

            Database.SetInitializer(
              new MigrateDatabaseToLatestVersion<BlogDbContext, Configuration>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
