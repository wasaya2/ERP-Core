using ErpCore.Entities;
using ErpCore.Entities.Finance;
using FinanceService.Repos.Base;
using FinanceService.Repos.Interfaces;
using FinanceService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceService.Repos
{
    public class AccountRepository : RepoBase<Account>, IAccountRepository
    {
        public string ConfigureComanyFinanceDetails(CompanyFinanceConfigurationViewModel model)
        {
            try
            {
                Company comp = Db.Companies.Find(model.CompanyId);
                comp.NTN = model.NTN;
                comp.AssetsAccountId = model.AssestsAccountId;
                comp.ExpenseAccountId = model.ExpenseAccountId;
                comp.RevenueAccountId = model.RevenueAccountId;
                comp.LiabilitiesAccountId = model.LiabilitiesAccountId;
                comp.EquityAccountId = model.EquityAccountId;
                Db.SaveChanges();
                return "Company finances configured";
            }
            catch(Exception)
            {
                return "Unable to apply configuration";
            }
        }
    }
}
