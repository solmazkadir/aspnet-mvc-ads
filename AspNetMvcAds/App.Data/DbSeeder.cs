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
                Name = "moderator"
            };
            dbContext.Roles.Add(roleModerator);
            
            var roleVisitor = new Role
            {
                Name = "kullanici"
            };
            dbContext.Roles.Add(roleVisitor);

            await dbContext.SaveChangesAsync();

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
            dbContext.Users.Add(modUser);
            
            var visUser = new User
            {
                Email = "kullanici@ads.com",
                Name = "kullanici",
                Password = "123",
                RoleId = roleVisitor.Id,
            };
            dbContext.Users.Add(visUser);

            await dbContext.SaveChangesAsync();
            //Kategoriler başlangıcı
            var kategori1 = new Category
            {
                Name="Araba",
                Description = "Test Araba"
            };
            dbContext.Categories.Add(kategori1);

            await dbContext.SaveChangesAsync();

            //Kategoriler bitişi

            //Advert Başlangıcı
            var advert1 = new Advert
            {
                Title ="Test Başlık",
                Description ="Test açıklama",
                UserId = 1,
            };
            dbContext.Adverts.Add(advert1);

            await dbContext.SaveChangesAsync();
            //Advert Bitiş

            //Advert Comment başlangıç
            var advertcomment1 = new AdvertComment
            {
                AdvertId = 1,
                UserId = 1,
                Comment = "Test yorum",
                IsActive = true,
            };
            dbContext.AdvertComments.Add(advertcomment1);

            await dbContext.SaveChangesAsync();

        }

    }
}
