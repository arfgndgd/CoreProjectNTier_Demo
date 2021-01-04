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
            //ServiceExtension içindeki sýnýflarýn configurasyonu
            //Manual Extension yaptýgýmýzda kullanacagýmýz yöntemin icerisindeki metotlarý tetiklemek
            //services.AddRepAndManServices(); //=> Extension metodumuz ile servisimizi kullanmak
            //services.AddDbContextService(); //Manuel kullaným
            //services.AddIdentityService();


            // Normal(N - Layered olmayan normal projelerde) Dependency Injection yapýsý Core'da su sekilde kurulur

            //Core'un otomatik olarak hangi Interface'i nasýl algýlayacagýný belirten bir mimarisi vardýr...Bu sisteme sizin özellikle bir nesne göndermenize gerek yoktur bu otomatik yapýlýr. Ancak hangi Interface'in olacagýný belirtmelisiniz...

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

            //Her sýnýf tetikleniþi icin ayrý bir instance alýr

            /*
            public IActionResult Deneme(IProductRepository item,IProductRepository item2)
            {

            }
             
             */
            #endregion

            //Yukarýdaki demek istedigimiz þey proje bir yerde IProductRepository gördügünde ona nesne olarak ne göndermeli onu söylemektir...Dikkat ederseniz burada instance alma iþlemini bile siz yapmýyorsunuz... Bu instance alma iþlemi Dependency Injection'ýn Core'da otomatik olarak entegre edilmesiyle gercekleþiyor...AddSingleton ilgili nesne icin bir SingletonPattern görevi görürken,AddScoped bir HTTPRequest'i icin sadece bir nesne alma görevi görürken,AddTransient her class tetiklendiginde bir nesne yaratan bir Dependenjy Injection iþlemi yapar...

            // Eger katmanlý bir yapý kuruyorsanýz bu AddTransient olayýný kendi mimarinize göre þekillendirmek zorundasýnýz...Bunun iki yöntemi vardýr...Ya Autofac kütüphanesi kullanarak Injection Extension yapmak (Yani Injection'ý geniþletmek) veya kendi Extension metodunuzu static sýnýfta yaratarak bu Injection Extension'i manual yapmak...


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
