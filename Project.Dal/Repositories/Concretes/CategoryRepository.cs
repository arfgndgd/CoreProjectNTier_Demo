using Project.Dal.Context;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Dal.Repositories.Concretes
{
    //services.AddScoped<ICategoryRepository>().As<CategoryRepository>(); // => bu ifade programa sunu der : Sen ICategoryRepository'i bir parametre olarak gördügün anda CategoryRepository instance'ini al demektir

    //services.AddScoped<IRepository<>>().As<BaseRepository<>>(); 

    //services.AddScoped<IProductRepository>().As<ProductRepository>();
    public class CategoryRepository:BaseRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(MyContext db):base(db)
        {

        }
    }
}
