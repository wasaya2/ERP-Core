using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eTrackerInfrastructure.Repos.Interfaces;
using eTrackerInfrastructure.Models.ReportViewModel;
using System.Globalization;

namespace eTrackerInfrastructure.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        //private IReportRepository Repo { get; set; }

        //private string[] formats = {"dd/MM/yyyy", "dd-MMM-yyyy", "yyyy-MM-dd",
        //           "dd-MM-yyyy", "M/d/yyyy", "dd MMM yyyy"};

        //public ReportController(IReportRepository repo)
        //{
        //    Repo = repo;
        //}

        //[HttpGet("GetShopRegistrationSummaryReport/{StartDate}/{EndDate}", Name = "GetShopRegistrationSummaryReport")]
        //public async Task<IList<ShopRegistrationSummaryViewModel>> GetShopRegistrationSummaryReport(string StartDate, string EndDate)
        //{
        //    if (StartDate == null || EndDate == null)
        //        return new List<ShopRegistrationSummaryViewModel>();

        //    var result = await Repo.GetSQLData<ShopRegistrationSummaryViewModel>($"select * from [dbo].[fn_registrationvisitsummary] ('{StartDate}', '{EndDate}')", Enums.ReportType.ShopRegistrationSummary);
        //        return result;
        //}

        //[HttpGet("GetShopVisitSummary/{StartDate}/{EndDate}", Name = "GetShopVisitSummary")]
        //public async Task<IList<ShopVisitSummaryViewModel>> GetShopVisitSummary(string StartDate, string EndDate)
        //{
        //    if (StartDate == null || EndDate == null)
        //        return new List<ShopVisitSummaryViewModel>();

        //    var result = await Repo.GetSQLData<ShopVisitSummaryViewModel>($"select * from [dbo].[fn_storevisitsummary] ('{StartDate}', '{EndDate}')", Enums.ReportType.ShopVisitSummary);
        //    return result;
        //}

        //[HttpGet("GetShopRegistrationReport/{StartDate}/{EndDate}", Name = "GetShopRegistrationReport")]
        //public async Task<IList<ShopRegistrationViewModel>> GetShopRegistrationReport(string StartDate, string EndDate)
        //{
        //    if (StartDate == null || EndDate == null)
        //        return new List<ShopRegistrationViewModel>();

        //    var result = await Repo.GetSQLData<ShopRegistrationViewModel>($"select * from [dbo].[fn_storesregistered] ('{StartDate}', '{EndDate}')", Enums.ReportType.ShopRegistration);
        //    return result;
        //}


        //[HttpGet("GetMileageHistory/{Date}", Name = "GetMileageHistory")]
        //public async Task<IList<MileageReportViewModel>> GetMileageHistory(string Date)
        //{
        //    if (Date == null)
        //        return new List<MileageReportViewModel>();

        //    var result = await Repo.GetSQLData<MileageReportViewModel>($"select * from [dbo].[fn_mileagehistory] ('{Date}')", Enums.ReportType.MileageReport);
        //    return result;
        //}
    }
}