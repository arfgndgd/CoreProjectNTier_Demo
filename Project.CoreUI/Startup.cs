using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.Bll.ServiceExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.CoreUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAuthentication();
            //ServiceExtension i�indeki s�n�flar�n configurasyonu
            //Manual Extension yapt�g�m�zda kullanacag�m�z y�ntemin icerisindeki metotlar� tetiklemek
            //services.AddRepAndManServices(); //=> Extension metodumuz ile servisimizi kullanmak
            //services.AddDbContextService(); //Manuel kullan�m
            //services.AddIdentityService();


            // Normal(N - Layered olmayan normal projelerde) Dependency Injection yap�s� Core'da su sekilde kurulur

            //Core'un otomatik olarak hangi Interface'i nas�l alg�layacag�n� belirten bir mimarisi vard�r...Bu sisteme sizin �zellikle bir nesne g�ndermenize gerek yoktur bu otomatik yap�l�r. Ancak hangi Interface'in olacag�n� belirtmelisiniz...

            #region AddScoped
            //services.AddScoped<IProductRepository,ProductRepository>().;

            /*
             public IActionResult Deneme(IProductRepository item , IProductRepository item2)
            {
            
                return View();
            }
     
             */

            #endregion


            //services.AddSingleton<IProductRepository,ProductRepository>().;


            #region AddTransient
            //services.AddTransient<IProductRepository,ProductRepository>(); 

            //Her s�n�f tetikleni�i icin ayr� bir instance al�r

            /*
            public IActionResult Deneme(IProductRepository item,IProductRepository item2)
            {

            }
             
             */
            #endregion

            //Yukar�daki demek istedigimiz �ey proje bir yerde IProductRepository g�rd�g�nde ona nesne olarak ne g�ndermeli onu s�ylemektir...Dikkat ederseniz burada instance alma i�lemini bile siz yapm�yorsunuz... Bu instance alma i�lemi Dependency Injection'�n Core'da otomatik olarak entegre edilmesiyle gercekle�iyor...AddSingleton ilgili nesne icin bir SingletonPattern g�revi g�r�rken,AddScoped bir HTTPRequest'i icin sadece bir nesne alma g�revi g�r�rken,AddTransient her class tetiklendiginde bir nesne yaratan bir Dependenjy Injection i�lemi yapar...

            // Eger katmanl� bir yap� kuruyorsan�z bu AddTransient olay�n� kendi mimarinize g�re �ekillendirmek zorundas�n�z...Bunun iki y�ntemi vard�r...Ya Autofac k�t�phanesi kullanarak Injection Extension yapmak (Yani Injection'� geni�letmek) veya kendi Extension metodunuzu static s�n�fta yaratarak bu Injection Extension'i manual yapmak...


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
