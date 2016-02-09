﻿using System.Linq;
using GiftBox.Common;
using GiftBox.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GiftBox.Data.Migrations
{
    internal static class DataSeeder
    {
        internal static void SeedAdmin(GiftBoxDbContext context)
        {
            const string AdminEmail = "adrian.apostolov.1991@gmail.com";
            const string AdminPassword = "123456";

            if (context.Users.Any(u => u.Email == AdminEmail))
            {
                return;
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));

            var admin = new User
            {
                FirstName = "Adrian",
                LastName = "Apostolov",
                Email = AdminEmail,
                UserName = AdminEmail,
                PhoneNumber = "0889972697",
                ImageUrl = GlobalConstants.DefaultUserPicture,
            };

            userManager.Create(admin, AdminPassword);
            userManager.AddToRole(admin.Id, GlobalConstants.AdminRole);
            userManager.AddToRole(admin.Id, GlobalConstants.UserRole);
            userManager.AddToRole(admin.Id, GlobalConstants.HomeAdministrator);


            context.SaveChanges();
        }

        internal static void SeedRoles(GiftBoxDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            roleManager.Create(new IdentityRole { Name = GlobalConstants.HomeAdministrator });
            roleManager.Create(new IdentityRole { Name = GlobalConstants.AdminRole });
            roleManager.Create(new IdentityRole { Name = GlobalConstants.UserRole });

            context.SaveChanges();
        }
    }
}