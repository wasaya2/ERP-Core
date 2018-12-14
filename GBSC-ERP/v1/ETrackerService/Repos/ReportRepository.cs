using eTrackerInfrastructure.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.Repos
{
    public static class NullSafeGetter
    {
        public static T GetValueOrDefault<T>(this IDataRecord row, string fieldName)
        {
            int ordinal = row.GetOrdinal(fieldName);
            return row.GetValueOrDefault<T>(ordinal);
        }

        public static T GetValueOrDefault<T>(this IDataRecord row, int ordinal)
        {
            return (T)(row.IsDBNull(ordinal) ? default(T) : row.GetValue(ordinal));
        }
    }


    public class ReportRepository : IReportRepository
    {

        //private List<ShopRegistrationSummaryViewModel> shopregistrationsumm;
        //private List<ShopRegistrationViewModel> shopregistration;
        //private List<ShopVisitSummaryViewModel> shopvisits;
        //private List<MileageReportViewModel> mileagehistory;


        //public ReportRepository()
        //{
        //    shopregistrationsumm = new List<ShopRegistrationSummaryViewModel>();
        //    shopregistration = new List<ShopRegistrationViewModel>();
        //    shopvisits = new List<ShopVisitSummaryViewModel>();
        //    mileagehistory = new List<MileageReportViewModel>();
        //}

        //public async Task<IList<T>> GetSQLData<T>(string query, Enums.ReportType type)
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        using (var command = context.Database.GetDbConnection().CreateCommand())
        //        {
        //            command.CommandText = query;
        //            context.Database.OpenConnection();
        //            using (var result = await command.ExecuteReaderAsync())
        //            {
        //                if (result.HasRows)
        //                {
        //                    while (await result.ReadAsync())
        //                    {
        //                        if (type == Enums.ReportType.ShopRegistrationSummary)
        //                        {
        //                            var row = ReadSingleShopRegistrationSummary((IDataRecord)result);
        //                            shopregistrationsumm.Add(row);
        //                        }
        //                        else if (type == Enums.ReportType.ShopRegistration)
        //                        {
        //                            var row = ReadSingleShopRegistration((IDataRecord)result);
        //                            shopregistration.Add(row);
        //                        }
        //                        else if(type == Enums.ReportType.ShopVisitSummary)
        //                        {
        //                            var row = ReadSingleShopVisit((IDataRecord)result);
        //                            shopvisits.Add(row);
        //                        }
        //                        else if(type == Enums.ReportType.MileageReport)
        //                        {
        //                            var row = ReadMileageRow((IDataRecord)result);
        //                            mileagehistory.Add(row);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    if (type == Enums.ReportType.ShopRegistrationSummary)
        //        return shopregistrationsumm.Cast<T>().ToList();
        //    else if (type == Enums.ReportType.ShopRegistration)
        //        return shopregistration.Cast<T>().ToList();
        //    else if (type == Enums.ReportType.MileageReport)
        //        return mileagehistory.Cast<T>().ToList();
        //    else
        //        return shopvisits.Cast<T>().ToList();

        //}


        //private static ShopRegistrationSummaryViewModel ReadSingleShopRegistrationSummary(IDataRecord record)
        //{
        //    var row = new ShopRegistrationSummaryViewModel
        //    {
        //        UserId = record.GetValueOrDefault<int>(0),
        //        SalesPerson = record.GetValueOrDefault<string>(1),
        //        Distributor = record.GetValueOrDefault<string>(2),
        //        Territory = record.GetValueOrDefault<string>(3),
        //        Day = record.GetValueOrDefault<string>(4),
        //        ShopName = record.GetValueOrDefault<string>(5),
        //        CheckinTime = record.GetValueOrDefault<DateTime?>(6),
        //        CheckoutTime = record.GetValueOrDefault<DateTime?>(7),
        //        TotalTimeSpent = record.GetValueOrDefault<string>(8)
        //    };

        //    return row;
        //}

        //private static ShopRegistrationViewModel ReadSingleShopRegistration(IDataRecord record)
        //{

        //    var row = new ShopRegistrationViewModel
        //    {
        //        SalesPerson = record.GetValueOrDefault<string>(0),
        //        Distributor = record.GetValueOrDefault<string>(1),
        //        Territory = record.GetValueOrDefault<string>(2),
        //        TotalStoresRegistered = record.GetValueOrDefault<int>(3)
        //    };

        //    return row;
        //}

        //private static ShopVisitSummaryViewModel ReadSingleShopVisit(IDataRecord record)
        //{

        //    var row = new ShopVisitSummaryViewModel
        //    {
        //        SalesPerson = record.GetValueOrDefault<string>(0),
        //        Distributor = record.GetValueOrDefault<string>(1),
        //        Territory = record.GetValueOrDefault<string>(2),
        //        TargetStores = record.GetValueOrDefault<int>(3),
        //        StoresVisited = record.GetValueOrDefault<int>(4)
        //    };

        //    return row;
        //}

        //private static MileageReportViewModel ReadMileageRow(IDataRecord record)
        //{
        //    var row = new MileageReportViewModel
        //    {
        //        UserId = record.GetValueOrDefault<int>(0),
        //        SalesPerson = record.GetValueOrDefault<string>(1),
        //        Distributor = record.GetValueOrDefault<string>(2),
        //        Territory = record.GetValueOrDefault<string>(3),
        //        Area = record.GetValueOrDefault<string>(4),
        //        Region = record.GetValueOrDefault<string>(5),
        //        DistanceTravelled = record.GetValueOrDefault<double>(6)
        //    };

        //    return row;
        //}

    }
}
