using Core.DataAccess;
using Core.Entities;
using Core.Services.Abstractions;
using DataAccess;
using DataAccess.Contexts;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage
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

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddRouting(options => options.LowercaseUrls = true);

            #region Context

            services.AddDbContext<TaskManagerAppContext>(option => option
                    .UseSqlServer(Configuration.GetConnectionString("Kanan"), x => x.MigrationsAssembly("DataAccess")));

            #endregion

            #region Identity

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
                options.User.RequireUniqueEmail = true;
            })
              .AddRoles<Role>()
              .AddEntityFrameworkStores<TaskManagerAppContext>();

            services.AddIdentityCore<Staff>()
            .AddRoles<Role>()
            .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<Staff, Role>>()
            .AddEntityFrameworkStores<TaskManagerAppContext>()
            .AddTokenProvider<DataProtectorTokenProvider<Staff>>(TokenOptions.DefaultProvider);

            services.AddScoped<SignInManager<Staff>>();

            #endregion

            #region UnitOfWork

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion

            #region Services

            services.AddTransient<IAssignmentService, AssignmentService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<IStaffService, StaffService>();

            #endregion

            #region FluentValidation

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            #endregion
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

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=home}/{action=index}/{id?}"
                );

                routes.MapRoute(
                   name: "default",
                   template: "{controller}/{action}/{id?}",
                   defaults: new { controller = "home", action = "index" }
               );
            });
        }
    }
}
