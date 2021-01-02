using Microsoft.Extensions.DependencyInjection;
using Project.Bll.ManageServices.Abstracts;
using Project.Bll.ManageServices.Concretes;
using Project.Dal.Repositories.Abstracts;
using Project.Dal.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Bll.ServiceExtensions
{
    //Repository Manager Service Extension
    //Autofac.Extensions.DependencyInjection kütüphanesi çok önemli bu aşamada
    public static class RepManServiceExtension
    {
        public static IServiceCollection AddRepAndManServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>),typeof(BaseRepository<>)); 
            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            

            return services;
        }
    }
}
