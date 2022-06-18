using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalUI
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
            services.AddTransient<IUserDal, EfUserRepository>();
            services.AddTransient<ITaskModelDal,EfTaskModelRepository>();
            services.AddTransient<IHospitalDal, EfHospitalRepository>();
            services.AddTransient<IBranchDal,EfBranchRepository>();
            services.AddTransient<IDoctorDal,EfDoctorRepository>();
            services.AddTransient<ITaskModelDal,EfTaskModelRepository>();
            services.AddTransient<ICommentDal,EfCommentRepository>();
            services.AddTransient<ITaskModelService,TaskModelManager>();
            services.AddTransient<IUserService, UserManager>();
            services.AddTransient<IHospitalService, HospitalManager>();           
            services.AddTransient<IBranchService, BranchManager>();           
            services.AddTransient<IDoctorService, DoctorManager>();           
            services.AddTransient<ITaskModelService, TaskModelManager>();           
            services.AddTransient<ICommentService, CommentManager>();           
            services.AddTransient<HospitalDbContext, HospitalDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc();          
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddControllersWithViews();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                   .AddCookie(options =>
                   {
                       options.LoginPath = "/User/Index";
                       options.AccessDeniedPath = "/User/Index";
                       options.LogoutPath = "/User/Index";

                   });
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
            app.UseRouting();

            app.UseCookiePolicy();

            //app.UseSession();
            app.UseAuthentication();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Index}/{id?}");
            });
        }
    }
}
