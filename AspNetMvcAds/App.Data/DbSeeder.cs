using App.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public static class DbSeeder
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public static async Task Seed(AppDbContext dbContext)
        {
            var roleAdmin = new Role
            {
                Name = "Admin"
            };
            dbContext.Roles.Add(roleAdmin);

            var roleModerator = new Role
            {
                Name = "Admin"
            };
            dbContext.Roles.Add(roleModerator);

            var roleVisitor = new Role
            {
                Name = "Admin"
            };
            dbContext.Roles.Add(roleVisitor);


            var adminUser = new User
            {
                Email = "admin@ads.com",
                Name = "Admin",
                Password = "123",
                RoleId = roleAdmin.Id,
            };
            dbContext.Users.Add(adminUser);

            var modUser = new User
            {
                Email = "moderator@ads.com",
                Name = "moderator",
                Password = "123",
                RoleId = roleModerator.Id,
            };
            dbContext.Users.Add(adminUser);

            var visUser = new User
            {
                Email = "kullanici@ads.com",
                Name = "kullanici",
                Password = "123",
                RoleId = roleVisitor.Id,
            };
            dbContext.Users.Add(adminUser);

            //await dbContext.SaveChangesAsync();      SaveChanges hata veriyor


        }
    }
}
