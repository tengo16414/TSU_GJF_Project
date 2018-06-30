namespace GJF.DAL.Migrations
{
    using GJF.Domain.Entities;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GJF.DAL.GJFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GJFDbContext context)
        {
            context.Roles.AddOrUpdate(p => p.Name,
               new Role { Name = "SuperAdmin" },
               new Role { Name = "Admin" },
               new Role { Name = "User" });

            if (!context.Users.Any(u => u.UserName == "SuperAdmin"))
            {

                string userId = Guid.NewGuid().ToString();

                context.Users.AddOrUpdate(p => new { p.Id, p.UserName, p.FirstName, p.LastName, p.PasswordHash, p.IsDeleted },
                new User
                {
                    Id = userId,
                    UserName = "superadmin",
                    FirstName = "სუპერ",
                    LastName = "ადმინისტრატორი",
                    PasswordHash = new PasswordHasher().HashPassword("123456"),
                    IsDeleted = false
                }
                );


                context.UserRoles.AddOrUpdate(p => new { p.UserId, p.RoleId },
                   new UserRole
                   {
                       UserId = userId,
                       RoleId = 1
                   }
                );
            }
        }
    }
}
