using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PublishingHouse.BLL;
using PublishingHouse.BLL.Interfaces;
using PublishingHouse.BLL.MappingProfilers;
using PublishingHouse.BLL.Services;
using PublishingHouse.DAL;
using PublishingHouse.DAL.Entities;

namespace PublishingHouse
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }        

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PublishingHouseContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("PublishingHouseDb")));

            services.AddIdentity<Customer, IdentityRole>()
                .AddEntityFrameworkStores<PublishingHouseContext>();

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = Configuration["Authentication:Google:ClientId"];
                    options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                })
                .AddFacebook(options =>
                {
                    options.ClientId = Configuration["Authentication:Facebook:AppId"];
                    options.ClientSecret = Configuration["Authentication:Facebook:AppSecret"];
                });

            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(AuthorProfile).Assembly);
            services.AddAutoMapper(typeof(BookProfile).Assembly);
            services.AddAutoMapper(typeof(BookCategoryProfile).Assembly);
            services.AddAutoMapper(typeof(BookOrderProfile).Assembly);
            services.AddAutoMapper(typeof(BookProfile).Assembly);
            services.AddAutoMapper(typeof(CartProfile).Assembly);
            services.AddAutoMapper(typeof(CommentProfile).Assembly);
            services.AddAutoMapper(typeof(NotificationProvider).Assembly);
            services.AddAutoMapper(typeof(OrderProfile).Assembly);

            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterModule<BLLDependencyModule>();

            AutofacContainer = builder.Build();

            return new AutofacServiceProvider(AutofacContainer);
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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
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
