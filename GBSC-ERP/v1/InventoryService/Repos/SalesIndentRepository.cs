using ErpCore.Entities;
using ErpInfrastructure.Data;
using InventoryService.Repos.Base;
using InventoryService.Repos.Interfaces;
using InventoryService.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repos
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

    public class SalesIndentRepository : RepoBase<SalesIndent>,  ISalesIndentRepository
    {
        public IList<SalesIndentPharmacyViewModel> GetSalesIndentsByDay(DateTime date)
        {
            try
            {
                IList<SalesIndentPharmacyViewModel> records = new List<SalesIndentPharmacyViewModel>();
                var commandText = $"Select * from fn_GetSalesIndentsByDay('{date.Date}')";
                using (var context = new ApplicationDbContext())
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = commandText;
                        context.Database.OpenConnection();
                        using (var result = command.ExecuteReader())
                        {
                            if (result.HasRows)
                            {
                                while (result.Read())
                                {

                                    records.Add(new SalesIndentPharmacyViewModel
                                    {
                                        SalesIndentId = result.GetValueOrDefault<long>(0),
                                        SalesIndentItemId = result.GetValueOrDefault<long>(1),
                                        IssueDate = result.GetValueOrDefault<DateTime>(2),
                                        Quantity = result.GetValueOrDefault<double>(3),
                                        TotalTradeOfferPerItem = result.GetValueOrDefault<double>(4),
                                        TotalTradePricePerItem = result.GetValueOrDefault<double>(5),
                                        TradeOfferPricePerUnit = result.GetValueOrDefault<double>(6),
                                        Dosage = result.GetValueOrDefault<double>(7),
                                        IsPaid = result.GetValueOrDefault<bool>(8),
                                        TreatmentTimeInDays = result.GetValueOrDefault<double>(9),
                                        TreatmentStart = result.GetValueOrDefault<DateTime>(10),
                                        TreatmentEnd = result.GetValueOrDefault<DateTime>(11),
                                        InventoryItemName = result.GetValueOrDefault<string>(12),
                                        CostPrice = result.GetValueOrDefault<double>(13),
                                        RetailPrice = result.GetValueOrDefault<double>(14),
                                        ItemCode = result.GetValueOrDefault<string>(15),
                                        UnitName = result.GetValueOrDefault<string>(16),
                                        PackTypeName = result.GetValueOrDefault<string>(17),
                                        PackSize = result.GetValueOrDefault<double>(18),
                                        ProductTypeName = result.GetValueOrDefault<string>(19)
                                    });
                                }
                            }
                        }
                    }
                }

                return records;

            }
            catch (Exception e)
            {
                throw;
            }
        }


        public IList<SalesIndentPharmacyViewModel> GetSalesIndentsByMonth(DateTime date)
        {
            try
            {
                IList<SalesIndentPharmacyViewModel> records = new List<SalesIndentPharmacyViewModel>();
                var commandText = $"Select * from fn_GetSalesIndentsByMonth('{date.Date}')";
                using (var context = new ApplicationDbContext())
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = commandText;
                        context.Database.OpenConnection();
                        using (var result = command.ExecuteReader())
                        {
                            if (result.HasRows)
                            {
                                while (result.Read())
                                {

                                    records.Add(new SalesIndentPharmacyViewModel
                                    {
                                        SalesIndentId = result.GetValueOrDefault<long>(0),
                                        SalesIndentItemId = result.GetValueOrDefault<long>(1),
                                        IssueDate = result.GetValueOrDefault<DateTime>(2),
                                        Quantity = result.GetValueOrDefault<double>(3),
                                        TotalTradeOfferPerItem = result.GetValueOrDefault<double>(4),
                                        TotalTradePricePerItem = result.GetValueOrDefault<double>(5),
                                        TradeOfferPricePerUnit = result.GetValueOrDefault<double>(6),
                                        Dosage = result.GetValueOrDefault<double>(7),
                                        IsPaid = result.GetValueOrDefault<bool>(8),
                                        TreatmentTimeInDays = result.GetValueOrDefault<double>(9),
                                        TreatmentStart = result.GetValueOrDefault<DateTime>(10),
                                        TreatmentEnd = result.GetValueOrDefault<DateTime>(11),
                                        InventoryItemName = result.GetValueOrDefault<string>(12),
                                        CostPrice = result.GetValueOrDefault<double>(13),
                                        RetailPrice = result.GetValueOrDefault<double>(14),
                                        ItemCode = result.GetValueOrDefault<string>(15),
                                        UnitName = result.GetValueOrDefault<string>(16),
                                        PackTypeName = result.GetValueOrDefault<string>(17),
                                        PackSize = result.GetValueOrDefault<double>(18),
                                        ProductTypeName = result.GetValueOrDefault<string>(19)
                                    });
                                }
                            }
                        }
                    }
                }

                return records;

            }
            catch (Exception e)
            {
                throw;
            }
        }


        //public IEnumerable<SalesIndent> GetSalesIndentsByMonth(DateTime date)
        //{
        //    return Table.Where(a => a.IssueDate.Value.Month == date.Month && a.IssueDate.Value.Year == date.Year).Include(b => b.SalesIndentItems)

        //        .Include("SalesIndentItems.InventoryItem")
        //        .Include("SalesIndentItems.InventoryItem.PackType").Include("SalesIndentItems.InventoryItem.PackSize")
        //        .Include("SalesIndentItems.InventoryItem.Unit").Include("SalesIndentItems.Inventory")

        //        //.Include("SalesIndentItems.Inventory").Include("SalesIndentItems.InventoryItem").Include("SalesIndentItems.InventoryItem.Brand")
        //        //.Include("SalesIndentItems.InventoryItem.Unit").Include("SalesIndentItems.InventoryItem.PackType")
        //        //.Include("SalesIndentItems.InventoryItem.PackSize").Include("SalesIndentItems.InventoryItem.PackCategory")
        //        //.Include("SalesIndentItems.InventoryItem.ProductType").Include("SalesIndentItems.InventoryItem.InventoryItemCategory")
        //        //.Include("SalesIndentItems.InventoryItem.PackageType").Include("SalesIndentItems.InventoryItem.Inventory")

        //        .ToList().OrderByDescending(a => a.SalesIndentId);
        //}

        public SalesIndent GetSalesIndentDetailsByCode(string code)
        {
            try
            {
                if (Table.Where(a => a.SalesIndentNumber == code).Include(a => a.SalesOrder).FirstOrDefault().SalesOrder != null)
                    return null;

                return Table.Where(a => a.SalesIndentNumber == code).Include(b => b.SalesIndentItems).Include("SalesIndentItems.InventoryItem")
                    .Include("SalesIndentItems.InventoryItem.PackType").Include("SalesIndentItems.InventoryItem.PackSize")
                    .Include("SalesIndentItems.InventoryItem.Unit").Include("SalesIndentItems.Inventory")
                    .FirstOrDefault();
            }

            catch (NullReferenceException)
            {
                return null;
            }
        }
    }
}
