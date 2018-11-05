using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using ErpInfrastructure.Auth;
using Microsoft.AspNetCore.Identity;
using ErpCore.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ErpInfrastructure.Helpers;
using ErpCore.Entities;
using ErpInfrastructure.Data;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using InventoryService.Repos;
using InventoryService.Repos.Interfaces;

namespace InventoryService
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

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IComissionRepository, ComissionRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerBankRepository, CustomerBankRepository>();
            services.AddScoped<IDistributorRepository, DistributorRepository>();
            services.AddScoped<IItemPriceStructureRepository, ItemPriceStructureRepository>();
            services.AddScoped<IModeOfPaymentRepository, ModeOfPaymentRepository>();
            services.AddScoped<ISalesPersonRepository, SalesPersonRepository>();
            services.AddScoped<ITaxRepository, TaxRepository>();
            services.AddScoped<ITransportRepository, TransportRepository>();
            services.AddScoped<IInventoryItemCategoryRepository, InventoryItemCategoryRepository>();
            services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IUnitsRepository, UnitsRepository>(); 
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IPackCategoryRepository, PackCategoryRepository>();
            services.AddScoped<IPackSizeRepository, PackSizeRepository>();
            services.AddScoped<IPackTypeRepository, PackTypeRepository>();
            services.AddScoped<IPackageTypeRepository, PackageTypeRepository>();
            services.AddScoped<IReturnReasonRepository, ReturnReasonRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInventoryCurrencyRepository, InventoryCurrencyRepository>();

            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<ICustomerWarehousesRepository, CustomerWarehouseRepository>();
            services.AddScoped<ICustomerAccountRepository, CustomerAccountRepository>();
            services.AddScoped<ICustomerPricePickLevelRepository, CustomerPricePickLevelRepository>();
            services.AddScoped<ICustomerTypeRepository, CustomerTypeRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<ITerritoryRepository, TerritoryRepository>();

            //Sales
            services.AddScoped<ISalesIndentRepository, SalesIndentRepository>();
            services.AddScoped<ISalesIndentItemRepository, SalesIndentItemRepository>();

            services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();
            services.AddScoped<ISalesOrderItemRepository, SalesOrderItemRepository>();

            services.AddScoped<IDeliveryOrderRepository, DeliveryOrderRepository>();
            services.AddScoped<IDeliveryOrderItemRepository, DeliveryOrderItemRepository>();

            services.AddScoped<ISalesInvoiceRepository, SalesInvoiceRepository>();

            services.AddScoped<IDeliveryChallanRepository, DeliveryChallanRepository>();

            services.AddScoped<ISalesReturnItemRepository, SalesReturnItemRepository>();
            services.AddScoped<ISalesReturnRepository, SalesReturnRepository>();

            //Purchase
            services.AddScoped<IPurchaseIndentRepository, PurchaseIndentRepository>();
            services.AddScoped<IPurchaseIndentItemRepository, PurchaseIndentItemRepository>();
            
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddScoped<IPurchaseOrderItemRepository, PurchaseOrderItemRepository>();

            services.AddScoped<IPurchaseInvoiceRepository, PurchaseInvoiceRepository>();

            services.AddScoped<IGrnRepository, GrnRepository>();
            services.AddScoped<IGrnItemRepository, GrnItemRepository>();

            services.AddScoped<IPurchaseReturnRepository, PurchaseReturnRepository>();
            services.AddScoped<IPurchaseReturnItemRepository, PurchaseReturnItemRepository>();

            services.AddMvc().AddJsonOptions(options =>
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
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
