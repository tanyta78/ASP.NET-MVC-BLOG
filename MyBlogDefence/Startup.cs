using Microsoft.Owin;
using MyBlogDefence.Migrations;
using MyBlogDefence.Models;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(MyBlogDefence.Startup))]
namespace MyBlogDefence
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BlogDbContext, Configuration>());

            ConfigureAuth(app);
        }
    }
}
