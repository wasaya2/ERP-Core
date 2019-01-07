using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Models;
using ErpInfrastructure.Auth;
using ErpInfrastructure.Data;
using ErpInfrastructure.Helpers;
using FinanceService.Repos;
using FinanceService.Repos.Interfaces;
using FinanceService.Repos.Interfaces.SetupInterfaces;
using FinanceService.Repos.SetupRepos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace FinanceService
{
    public class Startup
    {
        private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IJwtFactory, JwtFactory>();
            services.AddSingleton<JwtIssuerOptions>();

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
            });

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
            });

            var buildr = services.AddIdentityCore<AppUser>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });

            buildr = new IdentityBuilder(buildr.UserType, typeof(IdentityRole), buildr.Services);
            buildr.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();

            //FinanceSetup
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionAccountRepository, TransactionAccountRepository>();

            services.AddScoped<IMasterAccountRepository, MasterAccountRepository>();
            services.AddScoped<IDetailAccountRepository, DetailAccountRepository>();
            services.AddScoped<ISubAccountRepository, SubAccountRepository>();
            services.AddScoped<ISecondSubAccountRepository, SecondSubAccountRepository>();
            services.AddScoped<IFinancialYearRepository, FinancialYearRepository>();
            services.AddScoped<IVoucherTypeRepository, VoucherTypeRepository>();

            //Finance
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<IVoucherDetailRepository, VoucherDetailRepository>();
            services.AddScoped<IUnpostedVoucherRepository, UnpostedVoucherRepository>();
            services.AddScoped<IPostedVoucherRepository, PostedVoucherRepository>();

            services.AddScoped<IFinanceSalesReturnRepository, FinanceSalesReturnRepository>();
            services.AddScoped<IFinanceSalesReturnDetailRepository, FinanceSalesReturnDetailRepository>();
            services.AddScoped<IFinanceSalesInvoiceRepository, FinanceSalesInvoiceRepository>();
            services.AddScoped<IFinanceSalesInvoiceDetailRepository, FinanceSalesInvoiceDetailRepository>();
            services.AddScoped<IFinancePurchaseReturnRepository, FinancePurchaseReturnRepository>();
            services.AddScoped<IFinancePurchaseReturnDetailRepository, FinancePurchaseReturnDetailRepository>();
            services.AddScoped<IFinancePurchaseInvoiceRepository, FinancePurchaseInvoiceRepository>();
            services.AddScoped<IFinancePurchaseInvoiceDetailRepository, FinancePurchaseInvoiceDetailRepository>();

            services.AddMvc().AddJsonOptions(options =>
                       options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Request.Path.StartsWithSegments("/api") &&
                   (context.HttpContext.Response.StatusCode == 401 ||
                    context.HttpContext.Response.StatusCode == 403))
                {
                    await context.HttpContext.Response.WriteAsync("Unauthorized request");
                }
            });

            app.UseExceptionHandler(
                builder =>
                {
                    builder.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                            var error = context.Features.Get<IExceptionHandlerFeature>();
                            if (error != null)
                            {
                                //context.Response.AddApplicationError(error.Error.Message);
                                await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                            }
                        });
                });


            app.UseCors("MyPolicy");
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
