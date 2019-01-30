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
using HimsService.Repos;
using HimsService.Repos.Interfaces;


namespace HimsService
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

            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IPatientPackageRepository, PatientPackageRepository>();   
            services.AddScoped<IPartnerRepository, PartnerRepository>();
            services.AddScoped<IPatientInvoiceItemRepository, PatientInvoiceItemRepository>();
            services.AddScoped<IPatientInvoiceRepository, PatientInvoiceRepository>();
            services.AddScoped<IPatientInvoiceReturnItemRepository, PatientInvoiceReturnItemRepository>();
            services.AddScoped<IPatientInvoiceReturnRepository, PatientInvoiceReturnRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<IVisitNatureRepository, VisitNatureRepository>();
            services.AddScoped<IPatientReferenceRepository, PatientReferenceRepository>();
            services.AddScoped<IPatientDocumentRepository, PatientDocumentRepository>();
            services.AddScoped<IConsultantRepository, ConsultantRepository>();

            services.AddScoped<IDailyProcedureRepository, DailyProcedureRepository>();
            services.AddScoped<IDailySemenAnalysis, DailySemenAnalysisRepository>();
            //Visit
            services.AddScoped<IPatientVitalRepository, PatientVitalRepository>();
            services.AddScoped<IDiagnosisRepository, DiagnosisRepository>();
            services.AddScoped<IVisitRepository, VisitRepository>();
            services.AddScoped<IVisitNoteRepository, VisitNoteRepository>();
            services.AddScoped<IVisitTestRepository, VisitTestRepository>();
            services.AddScoped<IVisitDiagnosisRepository, VisitDiagnosisRepository>();
            //Setup
            services.AddScoped<ITestTypeRepository, TestTypeRepository>();
            services.AddScoped<ITestCategoryRepository, TestCategoryRepository>();
            services.AddScoped<IProcedureRepository, ProcedureRepository>();
            services.AddScoped<ISonologistRepository, SonologistRepository>();

            //UltraSound

            services.AddScoped<IUltraSoundPelvisRepository, UltraSoundPelvisRepositiry>();
            services.AddScoped<IFwbInitialRepository, FwbInitialRepository>();
            services.AddScoped<IUltraSoundMasterRepository, UltraSoundMasterRepository >();

            //
            services.AddScoped<IOtPatientCaseRepository , OtPatientCaseRepository>();


            //Laboratory
            services.AddScoped<IEmbryologistRepository, EmbryologistRepository>();
            services.AddScoped<IEmbryologyCodeRepository, EmbryologistCodeRepository>();
            services.AddScoped<ITestUnitRepository, TestUnitRepository>();
            services.AddScoped<IReferenceRangeRepository, ReferenceRangeRepository>();
            services.AddScoped<IBioChemistryTestRepository, BioChemistryTestRepository>();
            services.AddScoped<IBioChemistryTestDetailsRepository, BioChemistryTestDetailsRepository>();
            services.AddScoped<IBioChemistryTestOnTreatmentRepository, BioChemistryTestOnTreatmentRepository>();
            services.AddScoped<IInseminationPrepRepository, InseminationPrepRepository>();
            services.AddScoped<ITvopuRepository, TvopuRepository>();
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ITreatmentTypeRepository, TreatmentTypeRepository>();
            services.AddScoped<IPatientClinicalRecordRepository, PatientClinicalRecordRepository>();
            services.AddScoped<IProtocolRepository, ProtocolRepository>();
            services.AddScoped<IPatientEmbryologyRepository, PatientEmbryologyRepository>();
            services.AddScoped<IThawAssessmentRepository, ThawAssessmentRepository>();
            services.AddScoped<IBiopsyRepository, BiopsyRepository>();
            services.AddScoped<IFreezePreprationRepository, FreezePreprationRepository>();
            services.AddScoped<IPatientInsemenationRepository, PatientInsemenationRepository>();
            services.AddScoped<ISemenAnalysisRepository, SemenAnalysisRepository>();
            services.AddScoped<IBioChemistryTestOutsiderRepository, BioChemistryTestOutsiderRepository>();
            

            services.AddMvc().AddJsonOptions(options =>
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
