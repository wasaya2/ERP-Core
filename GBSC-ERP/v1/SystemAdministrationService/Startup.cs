using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SystemAdministrationService.Repos;
using SystemAdministrationService.Repos.Interfaces;
using SystemAdministrationService.Repos.HrSetupRepos.HrSetupInterfaces;
using SystemAdministrationService.Repos.HrSetupRepos;
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
using SystemAdministrationService.Repos.Hr.LeaveRepos.Interfaces;
using SystemAdministrationService.Repos.Hr.LeaveRepos;
using SystemAdministrationService.Repos.LeaveRepos;
using SystemAdministrationService.Repos.Hr.PayrollRepos.Interfaces;
using SystemAdministrationService.Repos.Hr.PayrollRepos;
using PayrollService.Repos;
using SystemAdministrationService.Repos.Hr.AttendanceRepos.Interfaces;
using SystemAdministrationService.Repos.Hr.AttendanceRepos;

namespace SystemAdministrationService
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
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Id, Constants.Strings.JwtClaims.ApiAccess));
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

            //SysAdmin
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();

            //HrSetup
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICostCenterRepository, CostCenterRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<IEmployeeStatusRepository, EmployeeStatusRepository>();
            services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();
            services.AddScoped<IFunctionRepository, FunctionRepository>();
            services.AddScoped<IGazettedHolidaysRepository, GazettedHolidaysRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            //services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<IManagementLevelRepository, ManagementLevelRepository>();
            services.AddScoped<IReligionRepository, ReligionRepository>();
            services.AddScoped<ISkillLevelRepository, SkillLevelRepository>();
            services.AddScoped<IUniversityRepository, UniversityRepository>();
            services.AddScoped<IDegreeRepository, DegreeRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IRelationRepository, RelationRepository>();
            services.AddScoped<IUserDocumentRepository, UserDocumentRepository>();
            services.AddScoped<IUserPhotoRepository, UserPhotoRepository>();
            services.AddScoped<IWorkExperienceRepository, WorkExperienceRepository>();
            services.AddScoped<IUserCompanyRepository, UserCompanyRepository>();
            //Leave
            services.AddScoped<ILeaveYearRepository, LeaveYearRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveRequestDetailRepository, LeaveRequestDetailRepository>();
            services.AddScoped<ILeavePurposeRepository, LeavePurposeRepository>();
            services.AddScoped<ILeaveClosingRepository, LeaveClosingRepository>();
            services.AddScoped<ILeavePolicyRepository, LeavePolicyRepository>();
            services.AddScoped<ILeaveOpeningRepository, LeaveOpeningRepository>();
            services.AddScoped<ILeaveOpeningDetailRepository, LeaveOpeningDetailRepository>();  
            services.AddScoped<ILeavePolicyEmployeeRepository, LeavePolicyEmployeeRepository>();
            services.AddScoped<ILeaveClosingRepository, LeaveClosingRepository>();
            services.AddScoped<ILeaveApprovalRepository, LeaveApprovalRepository>();
            services.AddScoped<ILeaveApproverRepository, LeaveApproverRepository>();
            services.AddScoped<ILeaveDayTypeRepository, LeaveDayTypeRepository>();
            services.AddScoped<ILeaveEligibilityRepository, LeaveEligibilityRepository>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveSubTypeRepository, LeaveSubTypeRepository>();
            services.AddScoped<ILeaveTypeBalanceRepository, LeaveTypeBalanceRepository>(); 
            services.AddScoped<IProrateMatrixRepository, ProrateMatrixRepository>();
            services.AddScoped<IDecimalRoundingMatrixRepository, DecimalRoundingMatrixRepository>();
            
            //Payroll
            services.AddScoped<ILoanTypeRepository, LoanTypeRepository>();
            services.AddScoped<IUserLoanRepository, UserLoanRepository>(); 

            services.AddScoped<IStopSalaryRepository, StopSalaryRepository>(); 

            services.AddScoped<IAllowanceRepository, AllowanceRepository>(); 
            services.AddScoped<IAllowanceArrearRepository, AllowanceArrearRepository>(); 
            services.AddScoped<IAllowanceCalculationTypeRepository, AllowanceCalculationTypeRepository>(); 
            services.AddScoped<IAllowanceDeductionRepository, AllowanceDeductionRepository>(); 
            services.AddScoped<IAllowanceRateRepository, AllowanceRateRepository>(); 
            services.AddScoped<IBankAdviceTemplateRepository, BankAdviceTemplateRepository>(); 
            services.AddScoped<IBenefitRepository,  BenefitRepository>(); 
            services.AddScoped<IChequeTemplateRepository, ChequeTemplateRepository>(); 
            services.AddScoped<ICompensationTransactionRepository, CompensationTransactionRepository>(); 
            services.AddScoped<ICurrencyRepository, CurrencyRepository>(); 
            services.AddScoped<IFrequencyRepository, FrequencyRepository>(); 
            services.AddScoped<IFundSetupRepository, FundSetupRepository>(); 
            services.AddScoped<IGratuitySlabRepository, GratuitySlabRepository>(); 
            services.AddScoped<IGratuityRepository, GratuityRepository>(); 
            services.AddScoped<IGratuitySlabGratuityRepository, GratuitySlabGratuityRepository>(); 
            services.AddScoped<IGratuityTypeRepository, GratuityTypeRepository>(); 
            services.AddScoped<ILeavingReasonRepository, LeavingReasonRepository>(); 
            services.AddScoped<IMasterPayrollDetailRepository, MasterPayrollDetailRepository>(); 
            services.AddScoped<IMasterPayrollRepository, MasterPayrollRepository>();
            services.AddScoped<IPayrollRepository, PayrollRepository>(); 
            services.AddScoped<IPayrollBankRepository, PayrollBankRepository>(); 
            services.AddScoped<IPayrollTypeRepository, PayrollTypeRepository>(); 
            services.AddScoped<IPayrollYearRepository, PayrollYearRepository>(); 
            services.AddScoped<IPfPaymentRepository, PfPaymentRepository>(); 
            services.AddScoped<ISalaryCalculationTypeRepository, SalaryCalculationTypeRepository>(); 
            services.AddScoped<ISalaryStructureRepository, SalaryStructureRepository>(); 
            services.AddScoped<ISalaryStructureDetailRepository, SalaryStructureDetailRepository>(); 
            services.AddScoped<IUserSalaryRepository, UserSalaryRepository>(); 
            services.AddScoped<IIncomeTaxRuleRepository, IncomeTaxRuleRepository>(); 
            services.AddScoped<ITaxableIncomeAdjustmentRepository, TaxableIncomeAdjustmentRepository>(); 
            services.AddScoped<ITaxAdjustmentReasonRepository, TaxAdjustmentReasonRepository>(); 
            services.AddScoped<ITaxBenefitRepository, TaxBenefitRepository>(); 
            services.AddScoped<ITaxReliefRepository, TaxReliefRepository>(); 
            services.AddScoped<ITaxScheduleRepository, TaxScheduleRepository>(); 
            services.AddScoped<ITaxYearRepository, TaxYearRepository>();
            

            services.AddScoped<IGratuityRepository, GratuityRepository>(); 
            services.AddScoped<IMonthlyUserSalaryRepository, MonthlyUserSalaryRepository>(); 

            services.AddScoped<IPaySlipRepository, PaySlipRepository>(); 
            services.AddScoped<ITaxAdjustmentRepository, TaxAdjustmentRepository>();

            //Attendance
            services.AddScoped<IAttendanceFlagExemptionRepository, AttendanceFlagExemptionRepository>();
            services.AddScoped<IAttendanceRuleRepository, AttendanceRuleRepository>();

            services.AddScoped<IAssignRosterRepository, AssignRosterRepository>();
            services.AddScoped<IAttendanceFlagRepository, AttendanceFlagRepository>();
            services.AddScoped<IAttendanceRequestApproverRepository, AttendanceRequestApproverRepository>();
            services.AddScoped<IAttendanceRequestTypeRepository, AttendanceRequestTypeRepository>();
            services.AddScoped<IFlagCategoryRepository, FlagCategoryRepository>();
            services.AddScoped<IFlagEffectTypeRepository, FlagEffectTypeRepository>();
            services.AddScoped<IFlagTypeRepository, FlagTypeRepository>();
            services.AddScoped<IFlagValueRepository, FlagValueRepository>();
            services.AddScoped<IRosterRepository, RosterRepository>();
            services.AddScoped<IShiftRepository, ShiftRepository>();

            services.AddScoped<IOverTimeFlagRepository, OverTimeFlagRepository>();
            services.AddScoped<IOverTimeTypeRepository, OverTimeTypeRepository>();
            services.AddScoped<IEmployeeIncomingOtRepository, EmployeeIncomingOtRepository>();
            services.AddScoped<IEmployeeOutgoingOtRepository, EmployeeOutgoingOtRepository>();
            services.AddScoped<IEmployeeWorkingDayOtRepository, EmployeeWorkingDayOtRepository>();
            services.AddScoped<IEmployeeOffDayOtRepository, EmployeeOffDayOtRepository>();

            services.AddScoped<IAttendanceRequestRepository, AttendanceRequestRepository>();
            services.AddScoped<IEmployeeOverTimeEntitlementRepository, EmployeeOverTimeEntitlementRepository>();
            services.AddScoped<IOfficialVisitEntryRepository, OfficialVisitEntryRepository>();
            services.AddScoped<IOverTimeEntitlementRepository, OverTimeEntitlementRepository>();
            services.AddScoped<IUserRosterAttendanceRepository, UserRosterAttendanceRepository>();
            services.AddScoped<IShiftAttendanceFlagRepository, ShiftAttendanceFlagRepository>();

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
