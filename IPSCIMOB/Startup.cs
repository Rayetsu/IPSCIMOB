﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IPSCIMOB.Data;
using IPSCIMOB.Models;
using IPSCIMOB.Services;

namespace IPSCIMOB
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //var connection = @"Server=(localdb)\\mssqllocaldb;Database=aspnet-IPSCIMOB-62721098-BD60-4CA2-8125-8EB3F02474C3;Trusted_Connection=True;MultipleActiveResultSets=true";
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            //services.AddTransient<Seed>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            Func<Task> func = async () =>
            {
                if (!await roleManager.RoleExistsAsync("CIMOB"))
                {
                    var role = new IdentityRole("CIMOB");
                    await roleManager.CreateAsync(role);
                }

                if (!await roleManager.RoleExistsAsync("Aluno"))
                {
                    var role = new IdentityRole("Aluno");
                    await roleManager.CreateAsync(role);
                }

                if (!await roleManager.RoleExistsAsync("Funcionário"))
                {
                    var role = new IdentityRole("Funcionário");
                    await roleManager.CreateAsync(role);
                }
            };

            Task task = func();
            task.Wait();

            //seeder.Initialize();

            //seeder.SeedUsers(userManager);

             Seed.SeedData(context, userManager);
        }


        }
    }

