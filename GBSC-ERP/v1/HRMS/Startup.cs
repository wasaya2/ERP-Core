using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using HRMS.Repos;
using HRMS.Repos.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;

namespace HRMS
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IBloodGroupRepository, BloodGroupRepository>();
            services.AddScoped<ICostCenterRepository, CostCenterRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<IEmployeeStatusRepository, EmployeeStatusRepository>();
            services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();
            services.AddScoped<IFunctionRepository, FunctionRepository>();
            services.AddScoped<IGazettedHolidaysRepository, GazettedHolidaysRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<IManagementLevelRepository, ManagementLevelRepository>();
            services.AddScoped<IMaritalStatusRepository, MaritalStatusRepository>();
            services.AddScoped<IQualificationRepository, QualificationRepository>();
            services.AddScoped<IReligionRepository, ReligionRepository>();
            services.AddScoped<IShiftRepository, ShiftRepository>();
            services.AddScoped<ISkillLevelRepository, SkillLevelRepository>();
            services.AddScoped<IUniversityRepository, UniversityRepository>();
            services.AddScoped<IDegreeRepository, DegreeRepository>();
            services.AddScoped<IRosterRepository, RosterRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
            services.AddScoped<IAdvanceTypeRepository, AdvanceTypeRepository>();
            services.AddScoped<IAllowanceTypeRepository, AllowanceTypeRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IRelationRepository, RelationRepository>();
            services.AddScoped<IAllowanceTypeRepository, AllowanceTypeRepository>();
            services.AddAutoMapper();

            services
                .AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            //app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}
            //app.UseStatusCodePages(async context =>
            //{
            //    if (context.HttpContext.Request.Path.StartsWithSegments("/api") &&
            //       (context.HttpContext.Response.StatusCode == 401 ||
            //        context.HttpContext.Response.StatusCode == 403))
            //    {
            //        await context.HttpContext.Response.WriteAsync("Unauthorized request");
            //    }
            //});
            //app.UseExceptionHandler(
            //   builder =>
            //   {
            //       builder.Run(
            //           async context =>
            //           {
            //               context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //               context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            //               var error = context.Features.Get<IExceptionHandlerFeature>();
            //               if (error != null)
            //               {
            //                    //context.Response.AddApplicationError(error.Error.Message);
            //                    await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
            //               }
            //           });
            //   });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //CreateRoles(serviceProvider);
        }
        //private void CreateRoles(IServiceProvider serviceProvider)
        //{

        //    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        //    Task<IdentityResult> roleResult;
        //    string[] roles = { "HR" };
        //    string email = "shani_1799@yahoo.com";
        //    string username = "rootadmin";

        //    foreach (var item in roles)
        //    {
        //        //Check that there is an Administrator role and create if not
        //        Task<bool> hasAdminRole = roleManager.RoleExistsAsync(item);
        //        hasAdminRole.Wait();

        //        if (!hasAdminRole.Result)
        //        {
        //            roleResult = roleManager.CreateAsync(new IdentityRole(item));
        //            roleResult.Wait();
        //        }
        //    }


        //    //Check if the admin user exists and create it if not
        //    //Add to the Administrator role

        //    Task<AppUser> testUser = userManager.FindByEmailAsync(email);
        //    testUser.Wait();

        //    if (testUser.Result == null)
        //    {
        //        AppUser administrator = new AppUser();
        //        administrator.Email = email;
        //        administrator.UserName = username;

        //        Task<IdentityResult> newUser = userManager.CreateAsync(administrator, "admin123");
        //        newUser.Wait();

        //        if (newUser.Result.Succeeded)
        //        {
        //            Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(administrator, "HR");
        //            newUserRole.Wait();
        //        }
        //    }

        //}
    }
}
