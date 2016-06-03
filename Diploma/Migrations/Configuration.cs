using Diploma.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Diploma.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Diploma.DAL.MunicipalityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Diploma.DAL.MunicipalityContext context)
        {
            // Создаем роль администратора
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };

                manager.Create(role);
            }

            // Создам роль обычного пользователя
            if (!context.Roles.Any(r => r.Name == "user"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "user" };

                manager.Create(role);
            }

            // По ум. создаем админского пользователя
            if (!context.Users.Any(u => u.UserName == "vshirochenko"))
            {
                var store = new UserStore<AppUser>(context);
                var manager = new UserManager<AppUser>(store);
                var user = new AppUser { UserName = "vshirochenko" };

                manager.Create(user, "gjwsr100");
                manager.AddToRole(user.Id, "admin");
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
