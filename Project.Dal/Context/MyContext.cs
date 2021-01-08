using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Dal.DALModel;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Project.Dal.Context
{
    // Eğer kurmak istediğimiz veri tabanı yapısında Identity kullanacaksak DbContext'ten miras almamalıyız. Çünkü Identity kendi tabloları tamamen hazır bir yapı sunar ve bu hazır yapıyı DbContext sağlayamaz. Miras alacağımız sınıf "IdentityDbContext" olmalı

    public class MyContext:IdentityDbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

    }
}
