using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErpCore.Entities.InventorySetup;
using ErpInfrastructure.Data;
using InventoryService.Repos.Interfaces;
using ErpCore.Filters;
using System.Text.RegularExpressions;
using ErpCore.Entities;
using InventoryService.ViewModels;

namespace InventoryService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SetupController : Controller
    {
        private IInventoryItemRepository _repo;
        private IInventoryItemCategoryRepository cat_repo;
        private IUnitsRepository uni_repo;
        private IBrandRepository Brand_repo;
        private IComissionRepository Comission_repo;
        private ICustomerRepository Customer_repo;
        private IDistributorRepository Distributor_repo;
        private IItemPriceStructureRepository ItemPriceStructure_repo;
        private ITaxRepository Tax_repo;
        private ITransportRepository Transport_repo;
        private IModeOfPaymentRepository ModeOfPayment_repo;
        private ICustomerBankRepository CustomerBank_repo;
        private IProductTypeRepository ProductType_repo;
        private IPackCategoryRepository PackCategory_repo;
        private IPackSizeRepository PackSize_repo;
        private IPackTypeRepository PackType_repo;
        private ISupplierRepository Supplier_repo;
        private IPackageTypeRepository PackageType_repo;
        private IAreaRepository Area_repo;
        private ICityRepository cityRepo;
        private ICustomerWarehousesRepository Warehouse_repo;
        private ICustomerAccountRepository Account_repo;
        private ICustomerPricePickLevelRepository PricePickLevel_repo;
        private ICustomerTypeRepository Type_repo;
        private IRegionRepository Region_repo;
        private ITerritoryRepository Territory_repo;
        private ISectionRepository sectionRepo;
        private ISubsectionRepository subsectionRepo;
        private IReturnReasonRepository Reason_repo;
        private IInventoryRepository Inv_repo;
        private IInventoryCurrencyRepository Currency_repo;
        private IGeneralSKURepository gen_repo;


        public SetupController(
            IInventoryItemRepository repo,
            IInventoryItemCategoryRepository repo2,
            IUnitsRepository repo3,
            IBrandRepository repo4,
            IComissionRepository repo5,
            ICustomerRepository repo6,
            IDistributorRepository repo7,
            IItemPriceStructureRepository repo8,
            ITaxRepository repo10,
            ITransportRepository repo11,
            IModeOfPaymentRepository repo12,
            ICustomerBankRepository repo13,
            IProductTypeRepository repo14,
            IPackTypeRepository repo15,
            IPackSizeRepository repo16,
            IPackCategoryRepository repo17,
            ISupplierRepository repo18,
            IPackageTypeRepository repo19,
            IAreaRepository repo20,
            ICityRepository _cityRepo,
            ICustomerWarehousesRepository repo21,
            ICustomerAccountRepository repo22,
            ICustomerPricePickLevelRepository repo23,
            ICustomerTypeRepository repo24,
            IRegionRepository repo25,
            ITerritoryRepository repo26,
            ISectionRepository _sectionRepo,
            ISubsectionRepository _subsectionRepo,
            IReturnReasonRepository repo27,
            IInventoryRepository repo28,
            IInventoryCurrencyRepository repo29,
            IGeneralSKURepository repo30
            )

        {
            _repo = repo;
            cat_repo = repo2;
            uni_repo = repo3;
            Brand_repo = repo4;
            Comission_repo = repo5;
            Customer_repo = repo6;
            Distributor_repo = repo7;
            ItemPriceStructure_repo = repo8;
            Tax_repo = repo10;
            Transport_repo = repo11;
            ModeOfPayment_repo = repo12;
            CustomerBank_repo = repo13;
            ProductType_repo = repo14;
            PackType_repo = repo15;
            PackSize_repo = repo16;
            PackCategory_repo = repo17;
            Supplier_repo = repo18;
            PackageType_repo = repo19;
            Area_repo = repo20;
            sectionRepo = _sectionRepo;
            subsectionRepo = _subsectionRepo;
            Warehouse_repo = repo21;
            Account_repo = repo22;
            PricePickLevel_repo = repo23;
            Type_repo = repo24;
            Region_repo = repo25;
            cityRepo = _cityRepo;
            Territory_repo = repo26;
            Reason_repo = repo27;
            Inv_repo = repo28;
            Currency_repo = repo29;
            gen_repo = repo30;
        }

        //[HttpGet("GetInventorySetupPermissions/{userid}/{RoleId}/{featureid}", Name = "GetInventorySetupPermissions")]
        //public IEnumerable<Permission> GetInventorySetupPermissions(long userid, long RoleId, long featureid)
        //{
        //    IEnumerable<Permission> per = _repo.GetFeaturePermissions(userid, RoleId, featureid).Permissions.ToList();
        //    return per;
        //}

        #region Inventory Item
        [HttpGet("GetInventoryItems", Name = "GetInventoryItems")]
        public IEnumerable<InventoryItem> GetInventoryItems()
        {
            IEnumerable<InventoryItem> iv = _repo.GetAll();

            iv = iv.OrderByDescending(a => a.InventoryItemId);
            return iv;
        }


        [HttpGet("GetNonGeneralBrandsWithInventoryItems/{CompanyId}")]
        public IActionResult GetNonGeneralBrandsWithInventoryItems(long CompanyId)
        {
            var brands = Brand_repo.GetNonGeneralInventoryItems(CompanyId);

            return Json(brands);
        }

        [HttpGet("GetGeneralBrandsWithInventoryItems/{CompanyId}")]
        public IActionResult GetGeneralBrandsWithInventoryItems(long CompanyId)
        {
            var brands = Brand_repo.GetGeneralInventoryItems(CompanyId);

            return Json(brands);
        }

        [HttpGet("GetInventoryItem/{id}", Name = "GetInventoryItem")]
        public InventoryItem GetInventoryItem(long id) => _repo.GetFirst(i => i.InventoryItemId == id,
                                                                         a => a.Inventories,
                                                                         b => b.InventoryItemCategory,
                                                                         c => c.PackageType,
                                                                         d => d.PackCategory,
                                                                         e => e.PackSize,
                                                                         f => f.PackType,
                                                                         g => g.ProductType,
                                                                         h => h.MeasurementUnit);

        [HttpGet("GetInventoryItemByCode/{code}", Name = "GetInventoryItemByCode")]
        public InventoryItem GetInventoryItemByCode([FromRoute]string code) => _repo.GetFirst(i => i.ItemCode == code,
                                                                                                a => a.Inventories,
                                                                                                b => b.InventoryItemCategory,
                                                                                                c => c.PackageType,
                                                                                                d => d.PackCategory,
                                                                                                e => e.PackSize,
                                                                                                f => f.PackType,
                                                                                                g => g.ProductType,
                                                                                                h => h.MeasurementUnit);

        [HttpPut("UpdateInventoryItem", Name = "UpdateInventoryItem")]
        [ValidateModelAttribute]
        public IActionResult UpdateInventoryItem([FromBody]InventoryItem model)
        {
            _repo.Update(model);
            return new OkObjectResult(new { ItemID = model.InventoryItemId });
        }

        [HttpPost("AddInventoryItem", Name = "AddInventoryItem")]
        [ValidateModelAttribute]
        public IActionResult AddInventoryItem([FromBody]InventoryItem model)
        {
            _repo.Add(model);
            return new OkObjectResult(new { ItemID = model.InventoryItemId });
        }

        [HttpDelete("DeleteInventoryItem/{id}")]
        public IActionResult DeleteInventoryItem(long id)
        {
            InventoryItem inventoryItem = _repo.Find(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }
            _repo.Delete(inventoryItem);
            return Ok();
        }
        #endregion

        #region Area
        [HttpGet("GetAreas", Name = "GetAreas")]
        public IEnumerable<Area> GetAreas()
        {
            IEnumerable<Area> b = Area_repo.GetAll();
            b = b.OrderByDescending(a => a.AreaId);
            return b;
        }



        [HttpGet("GetAreasByCompany/{CompanyId}")]
        public IEnumerable<Area> GetAreasByCompany(long CompanyId)
        {
            IEnumerable<Area> b = Area_repo.GetList(c => c.CompanyId == CompanyId);
            b = b.OrderByDescending(a => a.AreaId);
            return b;
        }

        [HttpGet("GetAreasByUser/{id}")]
        public IEnumerable<Area> GetAreasByUser(long id) => Area_repo.GetList(u => u.UserId == id);

        [HttpGet("GetArea/{id}", Name = "GetArea")]
        public Area GetArea(long id) => Area_repo.GetFirst(a => a.AreaId == id);

        [HttpPut("UpdateArea", Name = "UpdateArea")]
        [ValidateModelAttribute]
        public IActionResult UpdateArea([FromBody]Area model)
        {
            Area_repo.Update(model);
            return new OkObjectResult(new { AreaID = model.AreaId });
        }

        [HttpPost("AddArea", Name = "AddArea")]
        [ValidateModelAttribute]
        public IActionResult AddArea([FromBody]Area model)
        {
            Area_repo.Add(model);
            return new OkObjectResult(new { AreaID = model.AreaId });
        }

        [HttpDelete("DeleteArea/{id}")]
        public IActionResult DeleteArea(long id)
        {
            Area Area = Area_repo.Find(id);
            if (Area == null)
            {
                return NotFound();
            }
            Area_repo.Delete(Area);
            return Ok();
        }
        #endregion

        #region City
        [HttpGet("GetCities")]
        public IEnumerable<City> GetCities()
        {
            IEnumerable<City> c = cityRepo.GetAll();
            c = c.OrderByDescending(a => a.CityId);
            return c;
        }

        [HttpGet("GetCitiesByUser/{id}")]
        public IEnumerable<City> GetCitiesByUser(long id) => cityRepo.GetList(u => u.UserId == id);

        [HttpGet("GetCitiesByCompany/{CompanyId}")]
        public IEnumerable<City> GetCitiesByCompany(long CompanyId)
        {
            IEnumerable<City> b = cityRepo.GetList(c => c.CompanyId == CompanyId);
            b = b.OrderByDescending(a => a.CityId);
            return b;
        }

        [HttpGet("GetCity/{id}")]
        public City GetCity(long id) => cityRepo.GetFirst(a => a.CityId == id);

        [HttpPut("UpdateCity")]
        [ValidateModelAttribute]
        public IActionResult UpdateCity([FromBody]City model)
        {
            cityRepo.Update(model);
            return new OkObjectResult(new { CityId = model.CityId });
        }

        [HttpPost("AddCity")]
        [ValidateModelAttribute]
        public IActionResult AddCity([FromBody]City model)
        {
            cityRepo.Add(model);
            return new OkObjectResult(new { CityId = model.CityId });
        }

        [HttpDelete("DeleteCity/{id}")]
        public IActionResult DeleteCity(long id)
        {
            City city = cityRepo.Find(id);
            if (city == null)
            {
                return NotFound();
            }
            cityRepo.Delete(city);
            return Ok();
        }
        #endregion

        #region Region
        [HttpGet("GetRegions", Name = "GetRegions")]
        public IEnumerable<Region> GetRegions()
        {
            IEnumerable<Region> b = Region_repo.GetAll();
            b = b.OrderByDescending(a => a.RegionId);
            return b;
        }

        [HttpGet("GetRegionsByUser/{id}")]
        public IEnumerable<Region> GetRegionsByUser(long id) => Region_repo.GetList(u=>u.UserId == id);

        [HttpGet("GetRegionsByCompany/{CompanyId}")]
        public IEnumerable<Region> GetRegionsByCompany(long CompanyId)
        {
            IEnumerable<Region> b = Region_repo.GetList(c => c.CompanyId == CompanyId);
            b = b.OrderByDescending(a => a.RegionId);
            return b;
        }

        [HttpGet("GetRegion/{id}", Name = "GetRegion")]
        public Region GetRegion(long id) => Region_repo.GetFirst(a => a.RegionId == id);

        [HttpPut("UpdateRegion", Name = "UpdateRegion")]
        [ValidateModelAttribute]
        public IActionResult UpdateRegion([FromBody]Region model)
        {
            Region_repo.Update(model);
            return new OkObjectResult(new { RegionID = model.RegionId });
        }

        [HttpPost("AddRegion", Name = "AddRegion")]
        [ValidateModelAttribute]
        public IActionResult AddRegion([FromBody]Region model)
        {
            Region_repo.Add(model);
            return new OkObjectResult(new { RegionID = model.RegionId });
        }

        [HttpDelete("DeleteRegion/{id}")]
        public IActionResult DeleteRegion(long id)
        {
            Region Region = Region_repo.Find(id);
            if (Region == null)
            {
                return NotFound();
            }
            Region_repo.Delete(Region);
            return Ok();
        }
        #endregion

        #region Territory
        [HttpGet("GetTerritories", Name = "GetTerritories")]
        public IEnumerable<Territory> GetTerritories()
        {
            IEnumerable<Territory> b = Territory_repo.GetAll(a => a.Area, c => c.Distributor);
            b = b.OrderByDescending(a => a.TerritoryId);
            return b;
        }

        [HttpGet("GetTerritoriesByUser/{id}")]
        public IEnumerable<Territory> GetTerritoriesByUser(long id) => Territory_repo.GetList(u => u.UserId == id);

        [HttpGet("GetTerritoriesByCompany/{CompanyId}")]
        public IEnumerable<Territory> GetTerritoriesByCompany(long CompanyId)
        {
            IEnumerable<Territory> b = Territory_repo.GetList(t => t.CompanyId == CompanyId);
            b = b.OrderByDescending(a => a.TerritoryId);
            return b;
        }

        [HttpGet("GetTerritoriesByDistributor/{DistributorId}")]
        public IEnumerable<Territory> GetTerritoriesByDistributor(long DistributorId)
        {
            IEnumerable<Territory> b = Territory_repo.GetList(t => t.DistributorId == DistributorId);
            b = b.OrderByDescending(a => a.TerritoryId);
            return b;
        }

        [HttpGet("GetTerritory/{id}", Name = "GetTerritory")]
        public Territory GetTerritory(long id) => Territory_repo.GetFirst(c => c.TerritoryId == id, a => a.Area, b => b.Distributor);

        [HttpPut("UpdateTerritory", Name = "UpdateTerritory")]
        [ValidateModelAttribute]
        public IActionResult UpdateTerritory([FromBody]Territory model)
        {
            Territory_repo.Update(model);
            return new OkObjectResult(new { TerritoryID = model.TerritoryId });
        }

        [HttpPost("AddTerritory", Name = "AddTerritory")]
        [ValidateModelAttribute]
        public IActionResult AddTerritory([FromBody]Territory model)
        {
            Territory_repo.Add(model);
            return new OkObjectResult(new { TerritoryID = model.TerritoryId });
        }

        [HttpDelete("DeleteTerritory/{id}")]
        public IActionResult DeleteTerritory(long id)
        {
            Territory Territory = Territory_repo.Find(id);
            if (Territory == null)
            {
                return NotFound();
            }
            Territory_repo.Delete(Territory);
            return Ok();
        }
        #endregion

        #region Section
        [HttpGet("GetSections")]
        public IEnumerable<Section> GetSections()
        {
            IEnumerable<Section> sections = sectionRepo.GetAll(a => a.Territory);
            sections = sections.OrderByDescending(a => a.SectionId);
            return sections;
        }

        [HttpGet("GetSectionsByCompany/{CompanyId}")]
        public IEnumerable<Section> GetSectionsByCompany(long CompanyId)
        {
            IEnumerable<Section> sections = sectionRepo.GetList(c => c.CompanyId == CompanyId);
            sections = sections.OrderByDescending(a => a.SectionId);
            return sections;
        }

        [HttpGet("GetSectionsByTerritory/{TerritoryId}")]
        public IEnumerable<Section> GetSectionsByTerritory(long TerritoryId)
        {
            IEnumerable<Section> sections = sectionRepo.GetList(c => c.TerritoryId == TerritoryId);
            sections = sections.OrderByDescending(a => a.SectionId);
            return sections;
        }

        [HttpGet("GetSection/{id}")]
        public Section GetSection(long id) => sectionRepo.GetFirst(c => c.SectionId == id);

        [HttpPut("UpdateSection")]
        [ValidateModelAttribute]
        public IActionResult UpdateSection([FromBody]Section model)
        {
            sectionRepo.Update(model);
            return new OkObjectResult(new { SectionId = model.SectionId });
        }

        [HttpPost("AddSection")]
        [ValidateModelAttribute]
        public IActionResult AddSection([FromBody]Section model)
        {
            sectionRepo.Add(model);
            return new OkObjectResult(new { SectionId = model.SectionId });
        }

        [HttpDelete("DeleteSection/{id}")]
        public IActionResult DeleteSection(long id)
        {
            Section section = sectionRepo.Find(id);
            if (section == null)
            {
                return NotFound();
            }
            sectionRepo.Delete(section);
            return Ok();
        }
        #endregion

        #region Subsection
        [HttpGet("GetSubsections")]
        public IEnumerable<Subsection> GetSubsections()
        {
            IEnumerable<Subsection> subsections = subsectionRepo.GetAll(a => a.Section);
            subsections = subsections.OrderByDescending(a => a.SubsectionId);
            return subsections;
        }

        [HttpGet("GetSubsectionsByCompany/{CompanyId}")]
        public IEnumerable<Subsection> GetSubsectionsByCompany(long CompanyId)
        {
            IEnumerable<Subsection> subsections = subsectionRepo.GetList(c => c.CompanyId == CompanyId);
            subsections = subsections.OrderByDescending(a => a.SubsectionId);
            return subsections;
        }

        [HttpGet("GetSubsection/{id}")]
        public Subsection GetSubsection(long id) => subsectionRepo.GetFirst(c => c.SubsectionId == id);

        [HttpPut("UpdateSubsection")]
        [ValidateModelAttribute]
        public IActionResult UpdateSubsection([FromBody]Subsection model)
        {
            subsectionRepo.Update(model);
            return new OkObjectResult(new { SubsectionId = model.SubsectionId });
        }

        [HttpPost("AddSubsection")]
        [ValidateModelAttribute]
        public IActionResult AddSubsection([FromBody]Subsection model)
        {
            subsectionRepo.Add(model);
            return new OkObjectResult(new { SubsectionId = model.SubsectionId });
        }

        [HttpDelete("DeleteSubsection/{id}")]
        public IActionResult DeleteSubsection(long id)
        {
            Subsection subsection = subsectionRepo.Find(id);
            if (subsection == null)
            {
                return NotFound();
            }
            subsectionRepo.Delete(subsection);
            return Ok();
        }
        #endregion

        #region Category
        [HttpGet("GetCategories", Name = "GetCategories")]
        public IEnumerable<InventoryItemCategory> GetCategories()
        {
            IEnumerable<InventoryItemCategory> ct = cat_repo.GetAll();
            ct = ct.OrderByDescending(a => a.InventoryItemCategoryId);
            return ct;
        }

        [HttpGet("GetCategoriesByCompany/{CompanyId}", Name = "GetCategoriesByCompany")]
        public IEnumerable<InventoryItemCategory> GetCategories(long CompanyId)
        {
            IEnumerable<InventoryItemCategory> ct = cat_repo.GetList(c => c.CompanyId == CompanyId);
            ct = ct.OrderByDescending(a => a.InventoryItemCategoryId);
            return ct;
        }

        [HttpGet("GetCategory/{id}", Name = "GetCategory")]
        public InventoryItemCategory GetCategory(long id) => cat_repo.GetFirst(a => a.InventoryItemCategoryId == id);


        [HttpPost("AddCategory", Name = "AddCategory")]
        [ValidateModelAttribute]
        public IActionResult AddCategory([FromBody]InventoryItemCategory model)
        {
            cat_repo.Add(model);
            return new OkObjectResult(new { CategoryID = model.InventoryItemCategoryId });
        }

        [HttpPut("UpdateCategory", Name = "UpdateCategory")]
        [ValidateModelAttribute]
        public IActionResult UpdateCategory([FromBody]InventoryItemCategory model)
        {
            cat_repo.Update(model);
            return new OkObjectResult(new { CategoryID = model.InventoryItemCategoryId });
        }

        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(long id)
        {
            InventoryItemCategory catItem = cat_repo.Find(id);
            if (catItem == null)
            {
                return NotFound();
            }
            cat_repo.Delete(catItem);
            return Ok();
        }

        #endregion

        #region Units
        [HttpGet("GetUnits", Name = "GetUnits")]
        public IEnumerable<Units> GetUnits()
        {
            IEnumerable<Units> un = uni_repo.GetAll();
            un = un.OrderByDescending(a => a.UnitId);
            return un;
        }

        [HttpGet("GetUnitsByCompany/{CompanyId}")]
        public IEnumerable<Units> GetUnitsByCompany(long CompanyId)
        {
            IEnumerable<Units> un = uni_repo.GetList(c => c.CompanyId == CompanyId);
            un = un.OrderByDescending(a => a.UnitId);
            return un;
        }

        [HttpGet("GetUnit/{id}", Name = "GetUnit")]
        public Units GetUnit(long id) => uni_repo.GetFirst(a => a.UnitId == id);

        [HttpPut("UpdateUnit", Name = "UpdateUnit")]
        [ValidateModelAttribute]
        public IActionResult UpdateUnit([FromBody]Units model)
        {
            uni_repo.Update(model);
            return new OkObjectResult(new { UnitID = model.UnitId });
        }

        [HttpPost("AddUnit", Name = "AddUnit")]
        [ValidateModelAttribute]
        public IActionResult AddUnit([FromBody]Units model)
        {
            uni_repo.Add(model);
            return new OkObjectResult(new { UnitID = model.UnitId });
        }

        [HttpDelete("DeleteUnit/{id}")]
        public IActionResult DeleteIUnit(long id)
        {
            Units unitItem = uni_repo.Find(id);
            if (unitItem == null)
            {
                return NotFound();
            }
            uni_repo.Delete(unitItem);
            return Ok();
        }
        #endregion

        #region Brand
        [HttpGet("GetBrands", Name = "GetBrands")]
        public IEnumerable<Brand> GetBrands()
        {
            IEnumerable<Brand> b = Brand_repo.GetAll();
            b = b.OrderByDescending(a => a.BrandId);
            return b;
        }

        [HttpGet("GetBrandsByCompanyId/{CompanyId}")]
        public IEnumerable<Brand> GetBrandsByCompanyId(long CompanyId)
        {
            IEnumerable<Brand> b = Brand_repo.GetList(c => c.CompanyId == CompanyId);
            b = b.OrderByDescending(a => a.BrandId);
            return b;
        }

        [HttpGet("GetBrand/{id}", Name = "GetBrand")]
        public Brand GetBrand(long id) => Brand_repo.GetFirst(a => a.BrandId == id);

        [HttpPut("UpdateBrand", Name = "UpdateBrand")]
        [ValidateModelAttribute]
        public IActionResult UpdateBrand([FromBody]Brand model)
        {
            Brand_repo.Update(model);
            return new OkObjectResult(new { BrandID = model.BrandId });
        }

        [HttpPost("AddBrand", Name = "AddBrand")]
        [ValidateModelAttribute]
        public IActionResult AddBrand([FromBody]Brand model)
        {
            Brand_repo.Add(model);
            return new OkObjectResult(new { BrandID = model.BrandId });
        }

        [HttpDelete("DeleteBrand/{id}")]
        public IActionResult DeleteBrand(long id)
        {
            Brand Brand = Brand_repo.Find(id);
            if (Brand == null)
            {
                return NotFound();
            }
            Brand_repo.Delete(Brand);
            return Ok();
        }
        #endregion

        #region inventory Items Get By Company, Country, City or Branch

        [HttpGet("GetInventoryItemsByCompany/{id}", Name = "GetInventoryItemsByCompany")]
        public IEnumerable<InventoryItem> GetInventoryItemsByCompany(long id)
        {
            return _repo.GetList(a => a.CompanyId == id);
        }

        [HttpGet("GetInventoryItemsByCountry/{id}", Name = "GetInventoryItemsByCountry")]
        public IEnumerable<InventoryItem> GetInventoryItemsByCountry(long id)
        {
            return _repo.GetList(a => a.CountryId == id);
        }

        [HttpGet("GetInventoryItemsByCity/{id}", Name = "GetInventoryItemsByCity")]
        public IEnumerable<InventoryItem> GetInventoryItemsByCity(long id)
        {
            return _repo.GetList(a => a.CityId == id);
        }

        [HttpGet("GetInventoryItemsByBranch/{id}", Name = "GetInventoryItemsByBranch")]
        public IEnumerable<InventoryItem> GetInventoryItemsByBranch(long id)
        {
            return _repo.GetList(a => a.BranchId == id);
        }
        #endregion

        #region Comission
        [HttpGet("GetComissions", Name = "GetComissions")]
        public IEnumerable<Comission> GetComissions()
        {
            IEnumerable<Comission> b = Comission_repo.GetAll();
            b = b.OrderByDescending(a => a.ComissionId);
            return b;
        }

        [HttpGet("GetComissionsByCompany/{companyid}", Name = "GetComissionsByCompany")]
        public IEnumerable<Comission> GetComissionsByCompany([FromRoute]long companyid)
        {
            return Comission_repo.GetList(a => a.CompanyId != null && a.CompanyId == companyid).OrderByDescending(a => a.ComissionId);
        }

        [HttpGet("GetComission/{id}", Name = "GetComission")]
        public Comission GetComission(long id) => Comission_repo.GetFirst(a => a.ComissionId == id);

        [HttpPut("UpdateComission", Name = "UpdateComission")]
        [ValidateModelAttribute]
        public IActionResult UpdateComission([FromBody]Comission model)
        {
            Comission_repo.Update(model);
            return new OkObjectResult(new { ComissionID = model.ComissionId });
        }

        [HttpPost("AddComission", Name = "AddComission")]
        [ValidateModelAttribute]
        public IActionResult AddComission([FromBody]Comission model)
        {
            Comission_repo.Add(model);
            return new OkObjectResult(new { ComissionID = model.ComissionId });
        }

        [HttpDelete("DeleteComission/{id}")]
        public IActionResult DeleteComission(long id)
        {
            Comission Comission = Comission_repo.Find(id);
            if (Comission == null)
            {
                return NotFound();
            }
            Comission_repo.Delete(Comission);
            return Ok();
        }
        #endregion

        #region Customer
        [HttpGet("GetCustomers", Name = "GetCustomers")]
        public IEnumerable<Customer> GetCustomers()
        {
            IEnumerable<Customer> b = Customer_repo.GetAll();
            b = b.OrderByDescending(a => a.CustomerId);
            return b;
        }

        [HttpGet("GetCustomer/{id}", Name = "GetCustomer")]
        public Customer GetCustomer(long id) => Customer_repo.GetFirst(a => a.CustomerId == id);

        [HttpPut("UpdateCustomer", Name = "UpdateCustomer")]
        [ValidateModelAttribute]
        public IActionResult UpdateCustomer([FromBody]Customer model)
        {
            Customer_repo.Update(model);
            return new OkObjectResult(new { CustomerID = model.CustomerId });
        }

        [HttpPost("AddCustomer", Name = "AddCustomer")]
        [ValidateModelAttribute]
        public IActionResult AddCustomer([FromBody]Customer model)
        {
            model.RegDate = DateTime.Now;
            Customer_repo.Add(model);
            return new OkObjectResult(new { CustomerID = model.CustomerId });
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public IActionResult DeleteCustomer(long id)
        {
            Customer Customer = Customer_repo.Find(id);
            if (Customer == null)
            {
                return NotFound();
            }
            Customer_repo.Delete(Customer);
            return Ok();
        }
        #endregion

        #region Customer Warehouse
        [HttpGet("GetCustomerWarehouses", Name = "GetCustomerWarehouses")]
        public IEnumerable<CustomerWarehouse> GetCustomerWarehouses()
        {
            IEnumerable<CustomerWarehouse> b = Warehouse_repo.GetAll();
            b = b.OrderByDescending(a => a.CustomerWarehouseId);
            return b;
        }

        [HttpGet("GetCustomerWarehouse/{id}", Name = "GetCustomerWarehouse")]
        public CustomerWarehouse GetCustomerWarehouse(long id) => Warehouse_repo.GetFirst(a => a.CustomerWarehouseId == id);

        [HttpPut("UpdateCustomerWarehouse", Name = "UpdateCustomerWarehouse")]
        [ValidateModelAttribute]
        public IActionResult UpdateCustomerWarehouse([FromBody]CustomerWarehouse model)
        {
            Warehouse_repo.Update(model);
            return new OkObjectResult(new { CustomerWarehouseID = model.CustomerWarehouseId });
        }

        [HttpPost("AddCustomerWarehouse", Name = "AddCustomerWarehouse")]
        [ValidateModelAttribute]
        public IActionResult AddCustomerWarehouse([FromBody]CustomerWarehouse model)
        {
            Warehouse_repo.Add(model);
            return new OkObjectResult(new { CustomerWarehouseID = model.CustomerWarehouseId });
        }

        [HttpDelete("DeleteCustomerWarehouse/{id}")]
        public IActionResult DeleteCustomerWarehouse(long id)
        {
            CustomerWarehouse CustomerWarehouse = Warehouse_repo.Find(id);
            if (CustomerWarehouse == null)
            {
                return NotFound();
            }
            Warehouse_repo.Delete(CustomerWarehouse);
            return Ok();
        }
        #endregion

        #region Customer Account
        [HttpGet("GetCustomerAccounts", Name = "GetCustomerAccounts")]
        public IEnumerable<CustomerAccount> GetCustomerAccounts()
        {
            IEnumerable<CustomerAccount> b = Account_repo.GetAll();
            b = b.OrderByDescending(a => a.CustomerAccountId);
            return b;
        }

        [HttpGet("GetCustomerAccount/{id}", Name = "GetCustomerAccount")]
        public CustomerAccount GetCustomerAccount(long id) => Account_repo.GetFirst(a => a.CustomerAccountId == id);

        [HttpPut("UpdateCustomerAccount", Name = "UpdateCustomerAccount")]
        [ValidateModelAttribute]
        public IActionResult UpdateCustomerAccount([FromBody]CustomerAccount model)
        {
            Account_repo.Update(model);
            return new OkObjectResult(new { CustomerAccountID = model.CustomerAccountId });
        }

        [HttpPost("AddCustomerAccount", Name = "AddCustomerAccount")]
        [ValidateModelAttribute]
        public IActionResult AddCustomerAccount([FromBody]CustomerAccount model)
        {
            Account_repo.Add(model);
            return new OkObjectResult(new { CustomerAccountID = model.CustomerAccountId });
        }

        [HttpDelete("DeleteCustomerAccount/{id}")]
        public IActionResult DeleteCustomerAccount(long id)
        {
            CustomerAccount CustomerAccount = Account_repo.Find(id);
            if (CustomerAccount == null)
            {
                return NotFound();
            }
            Account_repo.Delete(CustomerAccount);
            return Ok();
        }
        #endregion

        #region Customer Price Pick Level
        [HttpGet("GetCustomerPricePickLevels", Name = "GetCustomerPricePickLevels")]
        public IEnumerable<CustomerPricePickLevel> GetCustomerPricePickLevels()
        {
            IEnumerable<CustomerPricePickLevel> b = PricePickLevel_repo.GetAll();
            b = b.OrderByDescending(a => a.CustomerPricePickLevelId);
            return b;
        }

        [HttpGet("GetCustomerPricePickLevel/{id}", Name = "GetCustomerPricePickLevel")]
        public CustomerPricePickLevel GetCustomerPricePickLevel(long id) => PricePickLevel_repo.GetFirst(a => a.CustomerPricePickLevelId == id);

        [HttpPut("UpdateCustomerPricePickLevel", Name = "UpdateCustomerPricePickLevel")]
        [ValidateModelAttribute]
        public IActionResult UpdateCustomerPricePickLevel([FromBody]CustomerPricePickLevel model)
        {
            PricePickLevel_repo.Update(model);
            return new OkObjectResult(new { CustomerPricePickLevelID = model.CustomerPricePickLevelId });
        }

        [HttpPost("AddCustomerPricePickLevel", Name = "AddCustomerPricePickLevel")]
        [ValidateModelAttribute]
        public IActionResult AddCustomerPricePickLevel([FromBody]CustomerPricePickLevel model)
        {
            PricePickLevel_repo.Add(model);
            return new OkObjectResult(new { CustomerPricePickLevelID = model.CustomerPricePickLevelId });
        }

        [HttpDelete("DeleteCustomerPricePickLevel/{id}")]
        public IActionResult DeleteCustomerPricePickLevel(long id)
        {
            CustomerPricePickLevel CustomerPricePickLevel = PricePickLevel_repo.Find(id);
            if (CustomerPricePickLevel == null)
            {
                return NotFound();
            }
            PricePickLevel_repo.Delete(CustomerPricePickLevel);
            return Ok();
        }
        #endregion

        #region Customer Type
        [HttpGet("GetCustomerTypes", Name = "GetCustomerTypes")]
        public IEnumerable<CustomerType> GetCustomerTypes()
        {
            IEnumerable<CustomerType> b = Type_repo.GetAll();
            b = b.OrderByDescending(a => a.CustomerTypeId);
            return b;
        }

        [HttpGet("GetCustomerType/{id}", Name = "GetCustomerType")]
        public CustomerType GetCustomerType(long id) => Type_repo.GetFirst(a => a.CustomerTypeId == id);

        [HttpPut("UpdateCustomerType", Name = "UpdateCustomerType")]
        [ValidateModelAttribute]
        public IActionResult UpdateCustomerType([FromBody]CustomerType model)
        {
            Type_repo.Update(model);
            return new OkObjectResult(new { CustomerTypeID = model.CustomerTypeId });
        }

        [HttpPost("AddCustomerType", Name = "AddCustomerType")]
        [ValidateModelAttribute]
        public IActionResult AddCustomerType([FromBody]CustomerType model)
        {
            Type_repo.Add(model);
            return new OkObjectResult(new { CustomerTypeID = model.CustomerTypeId });
        }

        [HttpDelete("DeleteCustomerType/{id}")]
        public IActionResult DeleteCustomerType(long id)
        {
            CustomerType CustomerType = Type_repo.Find(id);
            if (CustomerType == null)
            {
                return NotFound();
            }
            Type_repo.Delete(CustomerType);
            return Ok();
        }
        #endregion

        #region Distributor
        [HttpGet("GetDistributors", Name = "GetDistributors")]
        public IEnumerable<Distributor> GetDistributors()
        {
            IEnumerable<Distributor> b = Distributor_repo.GetAll();
            b = b.OrderByDescending(a => a.DistributorId);
            return b;
        }

        [HttpGet("GetDistributorsByCompany/{CompanyId}")]
        public IEnumerable<Distributor> GetDistributorsByCompany(long CompanyId)
        {
            IEnumerable<Distributor> b = Distributor_repo.GetList(d => d.CompanyId == CompanyId);
            b = b.OrderByDescending(a => a.DistributorId);
            return b;
        }

        [HttpGet("GetDistributor/{id}", Name = "GetDistributor")]
        public Distributor GetDistributor(long id) => Distributor_repo.GetFirst(a => a.DistributorId == id, t => t.Territories);

        [HttpPut("UpdateDistributor", Name = "UpdateDistributor")]
        [ValidateModelAttribute]
        public IActionResult UpdateDistributor([FromBody]Distributor model)
        {
            Distributor_repo.Update(model);
            return new OkObjectResult(new { DistributorID = model.DistributorId });
        }


        [HttpPost("AddDistributor", Name = "AddDistributor")]
        [ValidateModelAttribute]
        public IActionResult AddDistributor([FromBody]Distributor model)
        {
            Distributor_repo.Add(model);
            return new OkObjectResult(new { DistributorID = model.DistributorId });
        }

        [HttpPost("AddDistributorWithTerritories")]
        [ValidateModelAttribute]
        public IActionResult AddDistributorWithTerritories([FromBody]DistributorWithTerritoriesViewModel model)
        {
            var distributor = model.Distributor;
            //distributor.DRN = GenDRN();
            Distributor_repo.Add(distributor);

            var territories = new List<Territory>();

            foreach (var territoryId in model.TerritoryIds)
            {
                var territory = Territory_repo.Find(territoryId);
                if (territory != null)
                {
                    territory.DistributorId = distributor.DistributorId;
                    territories.Add(territory);
                }
            }

            if (territories.Count > 0)
                Territory_repo.UpdateRange(territories);

            return new OkObjectResult(new { DistributorId = distributor.DistributorId });
        }

        [HttpPost("UpdateDistributorWithTerritories")]
        [ValidateModelAttribute]
        public IActionResult UpdateDistributorWithTerritories([FromBody]DistributorWithTerritoriesViewModel model)
        {
            var distributor = model.Distributor;
            Distributor_repo.Update(distributor);
            //Remove Territories
            var territories = Territory_repo.GetList(d => d.DistributorId == distributor.DistributorId).ToList();

            foreach (var territory in territories)
            {
                territory.DistributorId = null;
            }

            if (territories.Count > 0)
                Territory_repo.UpdateRange(territories);


            //Re-assign Territories
            territories = new List<Territory>();

            foreach (var territoryId in model.TerritoryIds)
            {
                var territory = Territory_repo.Find(territoryId);
                if (territory != null)
                {
                    territory.DistributorId = distributor.DistributorId;
                    territories.Add(territory);
                }
            }

            if (territories.Count > 0)
                Territory_repo.UpdateRange(territories);

            return new OkObjectResult(new { DistributorId = distributor.DistributorId });
        }

        [HttpDelete("DeleteDistributor/{id}")]
        public IActionResult DeleteIDistributor(long id)
        {
            Distributor Distributor = Distributor_repo.Find(id);
            if (Distributor == null)
            {
                return NotFound();
            }
            Distributor_repo.Delete(Distributor);
            return Ok();
        }
        #endregion

        #region Item Price Structure
        [HttpGet("GetItemPriceStructures", Name = "GetItemPriceStructures")]
        public IEnumerable<ItemPriceStructure> GetItemPriceStructures()
        {
            IEnumerable<ItemPriceStructure> b = ItemPriceStructure_repo.GetAll();
            b = b.OrderByDescending(a => a.ItemPriceStructureId);
            return b;
        }

        [HttpGet("GetItemPriceStructure/{id}", Name = "GetItemPriceStructure")]
        public ItemPriceStructure GetItemPriceStructure(long id) => ItemPriceStructure_repo.GetFirst(a => a.ItemPriceStructureId == id);

        [HttpPut("UpdateItemPriceStructure", Name = "UpdateItemPriceStructure")]
        [ValidateModelAttribute]
        public IActionResult UpdateItemPriceStructure([FromBody]ItemPriceStructure model)
        {
            ItemPriceStructure_repo.Update(model);
            return new OkObjectResult(new { ItemPriceStructureID = model.ItemPriceStructureId });
        }

        [HttpPost("AddItemPriceStructure", Name = "AddItemPriceStructure")]
        [ValidateModelAttribute]
        public IActionResult AddItemPriceStructure([FromBody]ItemPriceStructure model)
        {
            ItemPriceStructure_repo.Add(model);
            return new OkObjectResult(new { ItemPriceStructureID = model.ItemPriceStructureId });
        }

        [HttpDelete("DeleteItemPriceStructure/{id}")]
        public IActionResult DeleteItemPriceStructure(long id)
        {
            ItemPriceStructure ItemPriceStructure = ItemPriceStructure_repo.Find(id);
            if (ItemPriceStructure == null)
            {
                return NotFound();
            }
            ItemPriceStructure_repo.Delete(ItemPriceStructure);
            return Ok();
        }
        #endregion

        #region Tax
        [HttpGet("GetTaxes", Name = "GetTaxes")]
        public IEnumerable<Tax> GetTaxes()
        {
            IEnumerable<Tax> b = Tax_repo.GetAll();
            b = b.OrderByDescending(a => a.TaxId);
            return b;
        }

        [HttpGet("GetTax/{id}", Name = "GetTax")]
        public Tax GetTax(long id) => Tax_repo.GetFirst(a => a.TaxId == id);

        [HttpPut("UpdateTax", Name = "UpdateTax")]
        [ValidateModelAttribute]
        public IActionResult UpdateTax([FromBody]Tax model)
        {
            Tax_repo.Update(model);
            return new OkObjectResult(new { TaxID = model.TaxId });
        }

        [HttpPost("AddTax", Name = "AddTax")]
        [ValidateModelAttribute]
        public IActionResult AddTax([FromBody]Tax model)
        {
            Tax_repo.Add(model);
            return new OkObjectResult(new { TaxID = model.TaxId });
        }

        [HttpDelete("DeleteTax/{id}")]
        public IActionResult DeleteTax(long id)
        {
            Tax Tax = Tax_repo.Find(id);
            if (Tax == null)
            {
                return NotFound();
            }
            Tax_repo.Delete(Tax);
            return Ok();
        }
        #endregion

        #region Transport
        [HttpGet("GetTransports", Name = "GetTransports")]
        public IEnumerable<Transport> GetTransports()
        {
            IEnumerable<Transport> b = Transport_repo.GetAll();
            b = b.OrderByDescending(a => a.TransportId);
            return b;
        }

        [HttpGet("GetTransport/{id}", Name = "GetTransport")]
        public Transport GetTransport(long id) => Transport_repo.GetFirst(a => a.TransportId == id);

        [HttpPut("UpdateTransport", Name = "UpdateTransport")]
        [ValidateModelAttribute]
        public IActionResult UpdateTransport([FromBody]Transport model)
        {
            Transport_repo.Update(model);
            return new OkObjectResult(new { TransportID = model.TransportId });
        }

        [HttpPost("AddTransport", Name = "AddTransport")]
        [ValidateModelAttribute]
        public IActionResult AddTransport([FromBody]Transport model)
        {
            Transport_repo.Add(model);
            return new OkObjectResult(new { TransportID = model.TransportId });
        }

        [HttpDelete("DeleteTransport/{id}")]
        public IActionResult DeleteTransport(long id)
        {
            Transport Transport = Transport_repo.Find(id);
            if (Transport == null)
            {
                return NotFound();
            }
            Transport_repo.Delete(Transport);
            return Ok();
        }
        #endregion

        #region Mode Of Payment
        [HttpGet("GetModeOfPayments", Name = "GetModeOfPayments")]
        public IEnumerable<ModeOfPayment> GetModeOfPayments()
        {
            IEnumerable<ModeOfPayment> b = ModeOfPayment_repo.GetAll();
            b = b.OrderByDescending(a => a.ModeOfPaymentId);
            return b;
        }

        [HttpGet("GetModeOfPayment/{id}", Name = "GetModeOfPayment")]
        public ModeOfPayment GetModeOfPayment(long id) => ModeOfPayment_repo.GetFirst(a => a.ModeOfPaymentId == id);

        [HttpPut("UpdateModeOfPayment", Name = "UpdateModeOfPayment")]
        [ValidateModelAttribute]
        public IActionResult UpdateModeOfPayment([FromBody]ModeOfPayment model)
        {
            ModeOfPayment_repo.Update(model);
            return new OkObjectResult(new { ModeOfPaymentID = model.ModeOfPaymentId });
        }

        [HttpPost("AddModeOfPayment", Name = "AddModeOfPayment")]
        [ValidateModelAttribute]
        public IActionResult AddModeOfPayment([FromBody]ModeOfPayment model)
        {
            ModeOfPayment_repo.Add(model);
            return new OkObjectResult(new { ModeOfPaymentID = model.ModeOfPaymentId });
        }

        [HttpDelete("DeleteModeOfPayment/{id}")]
        public IActionResult DeleteIModeOfPayment(long id)
        {
            ModeOfPayment ModeOfPayment = ModeOfPayment_repo.Find(id);
            if (ModeOfPayment == null)
            {
                return NotFound();
            }
            ModeOfPayment_repo.Delete(ModeOfPayment);
            return Ok();
        }
        #endregion

        #region Customer Bank
        [HttpGet("GetCustomerBanks", Name = "GetCustomerBanks")]
        public IEnumerable<CustomerBank> GetCustomerBanks()
        {
            IEnumerable<CustomerBank> b = CustomerBank_repo.GetAll();
            b = b.OrderByDescending(a => a.CustomerBankId);
            return b;
        }

        [HttpGet("GetCustomerBank/{id}", Name = "GetCustomerBank")]
        public CustomerBank GetCustomerBank(long id) => CustomerBank_repo.GetFirst(a => a.CustomerBankId == id);

        [HttpPut("UpdateCustomerBank", Name = "UpdateCustomerBank")]
        [ValidateModelAttribute]
        public IActionResult UpdateCustomerBank([FromBody]CustomerBank model)
        {
            CustomerBank_repo.Update(model);
            return new OkObjectResult(new { CustomerBankID = model.CustomerBankId });
        }

        [HttpPost("AddCustomerBank", Name = "AddCustomerBank")]
        [ValidateModelAttribute]
        public IActionResult AddCustomerBank([FromBody]CustomerBank model)
        {
            CustomerBank_repo.Add(model);
            return new OkObjectResult(new { CustomerBankID = model.CustomerBankId });
        }

        [HttpDelete("DeleteCustomerBank/{id}")]
        public IActionResult DeleteCustomerBank(long id)
        {
            CustomerBank CustomerBank = CustomerBank_repo.Find(id);
            if (CustomerBank == null)
            {
                return NotFound();
            }
            CustomerBank_repo.Delete(CustomerBank);
            return Ok();
        }
        #endregion

        #region Product Type
        [HttpGet("GetProductTypes", Name = "GetProductTypes")]
        public IEnumerable<ProductType> GetProductTypes()
        {
            IEnumerable<ProductType> b = ProductType_repo.GetAll();
            b = b.OrderByDescending(a => a.ProductTypeId);
            return b;
        }

        [HttpGet("GetProductTypesByCompany/{CompanyId}")]
        public IEnumerable<ProductType> GetProductTypesByCompany(long CompanyId)
        {
            IEnumerable<ProductType> b = ProductType_repo.GetList(c => c.CompanyId == CompanyId);
            b = b.OrderByDescending(a => a.ProductTypeId);
            return b;
        }

        [HttpGet("GetProductType/{id}", Name = "GetProductType")]
        public ProductType GetProductType(long id) => ProductType_repo.GetFirst(a => a.ProductTypeId == id);

        [HttpPut("UpdateProductType", Name = "UpdateProductType")]
        [ValidateModelAttribute]
        public IActionResult UpdateProductType([FromBody]ProductType model)
        {
            ProductType_repo.Update(model);
            return new OkObjectResult(new { ProductTypeID = model.ProductTypeId });
        }

        [HttpPost("AddProductType", Name = "AddProductType")]
        [ValidateModelAttribute]
        public IActionResult AddProductType([FromBody]ProductType model)
        {
            ProductType_repo.Add(model);
            return new OkObjectResult(new { ProductTypeID = model.ProductTypeId });
        }

        [HttpDelete("DeleteProductType/{id}")]
        public IActionResult DeleteProductType(long id)
        {
            ProductType Producttype = ProductType_repo.Find(id);
            if (Producttype == null)
            {
                return NotFound();
            }
            ProductType_repo.Delete(Producttype);
            return Ok();
        }
        #endregion

        #region Package Type
        [HttpGet("GetPackageTypes", Name = "GetPackageTypes")]
        public IEnumerable<PackageType> GetPackageTypes()
        {
            IEnumerable<PackageType> b = PackageType_repo.GetAll();
            b = b.OrderByDescending(a => a.PackageTypeId);
            return b;
        }

        [HttpGet("GetPackageTypesByCompany/{CompanyId}")]
        public IEnumerable<PackageType> GetPackageTypesByCompany(long CompanyId)
        {
            IEnumerable<PackageType> b = PackageType_repo.GetList(c => c.CompanyId == CompanyId);
            b = b.OrderByDescending(a => a.PackageTypeId);
            return b;
        }

        [HttpGet("GetPackageType/{id}", Name = "GetPackageType")]
        public PackageType GetPackageType(long id) => PackageType_repo.GetFirst(a => a.PackageTypeId == id);

        [HttpPut("UpdatePackageType", Name = "UpdatePackageType")]
        [ValidateModelAttribute]
        public IActionResult UpdatePackageType([FromBody]PackageType model)
        {
            PackageType_repo.Update(model);
            return new OkObjectResult(new { PackageTypeID = model.PackageTypeId });
        }

        [HttpPost("AddPackageType", Name = "AddPackageType")]
        [ValidateModelAttribute]
        public IActionResult AddPackageType([FromBody]PackageType model)
        {
            PackageType_repo.Add(model);
            return new OkObjectResult(new { PackageTypeID = model.PackageTypeId });
        }

        [HttpDelete("DeletePackageType/{id}")]
        public IActionResult DeletePackageType(long id)
        {
            PackageType Packagetype = PackageType_repo.Find(id);
            if (Packagetype == null)
            {
                return NotFound();
            }
            PackageType_repo.Delete(Packagetype);
            return Ok();
        }
        #endregion

        #region Pack Type
        [HttpGet("GetPackTypes", Name = "GetPackTypes")]
        public IEnumerable<PackType> GetPackTypes()
        {
            IEnumerable<PackType> b = PackType_repo.GetAll();
            b = b.OrderByDescending(a => a.PackTypeId);
            return b;
        }

        [HttpGet("GetPackTypesByCompany/{CompanyId}", Name = "GetPackTypesByCompany")]
        public IEnumerable<PackType> GetPackTypesByCompany(long CompanyId)
        {
            IEnumerable<PackType> b = PackType_repo.GetList(c => c.CompanyId == CompanyId);
            b = b.OrderByDescending(a => a.PackTypeId);
            return b;
        }

        [HttpGet("GetPackType/{id}", Name = "GetPackType")]
        public PackType GetPackType(long id) => PackType_repo.GetFirst(a => a.PackTypeId == id);

        [HttpPut("UpdatePackType", Name = "UpdatePackType")]
        [ValidateModelAttribute]
        public IActionResult UpdatePackType([FromBody]PackType model)
        {
            PackType_repo.Update(model);
            return new OkObjectResult(new { PackTypeID = model.PackTypeId });
        }

        [HttpPost("AddPackType", Name = "AddPackType")]
        [ValidateModelAttribute]
        public IActionResult AddPackType([FromBody]PackType model)
        {
            PackType_repo.Add(model);
            return new OkObjectResult(new { PackTypeID = model.PackTypeId });
        }

        [HttpDelete("DeletePackType/{id}")]
        public IActionResult DeletePackType(long id)
        {
            PackType Packtype = PackType_repo.Find(id);
            if (Packtype == null)
            {
                return NotFound();
            }
            PackType_repo.Delete(Packtype);
            return Ok();
        }
        #endregion

        #region Pack Size
        [HttpGet("GetPackSizes", Name = "GetPackSizes")]
        public IEnumerable<PackSize> GetPackSizes()
        {
            IEnumerable<PackSize> b = PackSize_repo.GetAll();
            b = b.OrderByDescending(a => a.PackSizeId);
            return b;
        }

        [HttpGet("GetPackSizesByCompany/{CompanyId}")]
        public IEnumerable<PackSize> GetPackSizesByCompany(long CompanyId)
        {
            IEnumerable<PackSize> b = PackSize_repo.GetList(c => c.CompanyId == CompanyId);
            b = b.OrderByDescending(a => a.PackSizeId);
            return b;
        }

        [HttpGet("GetPackSize/{id}", Name = "GetPackSize")]
        public PackSize GetPackSize(long id) => PackSize_repo.GetFirst(a => a.PackSizeId == id);

        [HttpPut("UpdatePackSize", Name = "UpdatePackSize")]
        [ValidateModelAttribute]
        public IActionResult UpdatePackSize([FromBody]PackSize model)
        {
            PackSize_repo.Update(model);
            return new OkObjectResult(new { PackSizeID = model.PackSizeId });
        }

        [HttpPost("AddPackSize", Name = "AddPackSize")]
        [ValidateModelAttribute]
        public IActionResult AddPackSize([FromBody]PackSize model)
        {
            PackSize_repo.Add(model);
            return new OkObjectResult(new { PackSizeID = model.PackSizeId });
        }

        [HttpDelete("DeletePackSize/{id}")]
        public IActionResult DeletePackSize(long id)
        {
            PackSize Packsize = PackSize_repo.Find(id);
            if (Packsize == null)
            {
                return NotFound();
            }
            PackSize_repo.Delete(Packsize);
            return Ok();
        }
        #endregion

        #region Pack Category
        [HttpGet("GetPackCategories", Name = "GetPackCategories")]
        public IEnumerable<PackCategory> GetPackCategories()
        {
            IEnumerable<PackCategory> b = PackCategory_repo.GetAll();
            b = b.OrderByDescending(a => a.PackCategoryId);
            return b;
        }

        [HttpGet("GetPackCategoriesByCompany/{CompanyId}")]
        public IEnumerable<PackCategory> GetPackCategoriesByCompany(long CompanyId)
        {
            IEnumerable<PackCategory> b = PackCategory_repo.GetList(c => c.CompanyId == CompanyId);
            b = b.OrderByDescending(a => a.PackCategoryId);
            return b;
        }

        [HttpGet("GetPackCategory/{id}", Name = "GetPackCategory")]
        public PackCategory GetPackCategory(long id) => PackCategory_repo.GetFirst(a => a.PackCategoryId == id);

        [HttpPut("UpdatePackCategory", Name = "UpdatePackCategory")]
        [ValidateModelAttribute]
        public IActionResult UpdatePackCategory([FromBody]PackCategory model)
        {
            PackCategory_repo.Update(model);
            return new OkObjectResult(new { PackCategoryID = model.PackCategoryId });
        }

        [HttpPost("AddPackCategory", Name = "AddPackCategory")]
        [ValidateModelAttribute]
        public IActionResult AddPackCategory([FromBody]PackCategory model)
        {
            PackCategory_repo.Add(model);
            return new OkObjectResult(new { PackCategoryID = model.PackCategoryId });
        }

        [HttpDelete("DeletePackCategory/{id}")]
        public IActionResult DeletePackCategory(long id)
        {
            PackCategory Packcategory = PackCategory_repo.Find(id);
            if (Packcategory == null)
            {
                return NotFound();
            }
            PackCategory_repo.Delete(Packcategory);
            return Ok();
        }
        #endregion

        #region Supplier

        [HttpGet("GetSuppliers", Name = "GetSuppliers")]
        public IEnumerable<Supplier> GetSuppliers()
        {
            IEnumerable<Supplier> sup = Supplier_repo.GetAll();
            sup = sup.OrderByDescending(s => s.SupplierId);
            return sup;
        }

        [HttpGet("GetSuppliersByCompany/{companyid}", Name = "GetSuppliersByCompany")]
        public IEnumerable<Supplier> GetSuppliersByCompany([FromRoute]long companyid)
        {
            return Supplier_repo.GetList(a => a.CompanyId == companyid).OrderByDescending(a => a.SupplierId);
        }

        [HttpGet("GetSupplier/{id}", Name = "GetSupplier")]
        public Supplier GetSupplier(long id) => Supplier_repo.GetFirst(s => s.SupplierId == id);

        [HttpPut("UpdateSupplier", Name = "UpdateSupplier")]
        [ValidateModelAttribute]
        public IActionResult UpdateSupplier([FromBody]Supplier model)
        {
            Supplier_repo.Update(model);
            return new OkObjectResult(new { SupplierID = model.SupplierId });
        }

        [HttpPost("AddSupplier", Name = "AddSupplier")]
        [ValidateModelAttribute]
        public IActionResult AddSupplier([FromBody]Supplier model)
        {
            Supplier_repo.Add(model);
            return new OkObjectResult(new { SupplierID = model.SupplierId });
        }

        [HttpDelete("DeleteSupplier/{id}")]
        public IActionResult DeleteSupplier(long id)
        {
            Supplier supplier = Supplier_repo.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }

            Supplier_repo.Delete(supplier);
            return Ok();
        }

        #endregion

        #region ReturnReason

        [HttpGet("GetReturnReasons", Name = "GetReturnReasons")]
        public IEnumerable<ReturnReason> GetReturnReasons()
        {
            IEnumerable<ReturnReason> rr = Reason_repo.GetAll();
            rr = rr.OrderByDescending(s => s.ReturnReasonId);
            return rr;
        }

        [HttpGet("GetReturnReason/{id}", Name = "GetReturnReason")]
        public ReturnReason GetReturnReason(long id) => Reason_repo.GetFirst(s => s.ReturnReasonId == id);

        [HttpPut("UpdateReturnReason", Name = "UpdateReturnReason")]
        [ValidateModelAttribute]
        public IActionResult UpdateReturnReason([FromBody]ReturnReason model)
        {
            Reason_repo.Update(model);
            return new OkObjectResult(new { ReturnReasonID = model.ReturnReasonId });
        }

        [HttpPost("AddReturnReason", Name = "AddReturnReason")]
        [ValidateModelAttribute]
        public IActionResult AddReturnReason([FromBody]ReturnReason model)
        {
            Reason_repo.Add(model);
            return new OkObjectResult(new { ReturnReasonID = model.ReturnReasonId });
        }

        [HttpDelete("DeleteReturnReason/{id}")]
        public IActionResult DeleteReturnReason(long id)
        {
            ReturnReason returnReason = Reason_repo.Find(id);
            if (returnReason == null)
            {
                return NotFound();
            }

            Reason_repo.Delete(returnReason);
            return Ok();
        }

        #endregion

        #region Inventory
        [HttpGet("GetInventories", Name = "GetInventories")]
        public IEnumerable<Inventory> GetInventories()
        {
            IEnumerable<Inventory> iv = Inv_repo.GetAll().OrderByDescending(a => a.InventoryId);
            iv = iv.OrderByDescending(a => a.InventoryId);
            return iv;
        }

        [HttpGet("GetInventoriesByCompany/{companyid}", Name = "GetInventoriesByCompany")]
        public IEnumerable<Inventory> GetInventoriesByCompany([FromRoute]long companyid)
        {
            return Inv_repo.GetList(a => a.CompanyId != null && a.CompanyId == companyid).OrderByDescending(a => a.InventoryId).OrderByDescending(a => a.InventoryId);
        }

        [HttpPost("UpdateInventoryList", Name = "UpdateInventoryList")]
        public IEnumerable<Inventory> UpdateInventoryList([FromBody]IList<long> ids)
        {
            IList<Inventory> inventories = new List<Inventory>();
            foreach(long id in ids)
            {
                inventories.Add(Inv_repo.Find(id));
            }
            return inventories.OrderByDescending(a => a.InventoryId);
        }

        [HttpGet("GetInventory/{id}", Name = "GetInventory")]
        public Inventory GetInventory(long id) => Inv_repo.GetFirst(a => a.InventoryId == id, b => b.InventoryItem);

        [HttpGet("GetInventoryByItemId/{id}", Name = "GetInventoryByItemId")]
        public Inventory GetInventoryByItemId(long id)
        {
            return Inv_repo.GetFirst(a => a.InventoryItemId == id);
        }

        //[HttpPut("UpdateInventories", Name = "UpdateInventories")]
        //[ValidateModelAttribute]
        //public IActionResult UpdateInventories([FromBody]IEnumerable<Inventory> models)
        //{
        //    Inv_repo.UpdateRange(models);
        //    return Ok();
        //}

        [HttpPut("UpdateInventory", Name = "UpdateInventory")]
        [ValidateModelAttribute]
        public IActionResult UpdateInventory([FromBody]Inventory model)
        {
            Inv_repo.Update(model);
            return new OkObjectResult(new { InventoryID = model.InventoryId });
        }

        [HttpPut("UpdateInventories", Name = "UpdateInventories")]
        [ValidateModelAttribute]
        public IActionResult UpdateInventories([FromBody]IEnumerable<Inventory> models)
        {
            Inv_repo.UpdateRange(models);
            return Ok("Updated");
        }

        [HttpPost("AddInventory", Name = "AddInventory")]
        [ValidateModelAttribute]
        public IActionResult AddInventory([FromBody]Inventory model)
        {
            Inv_repo.Add(model);
            return new OkObjectResult(new { InventoryID = model.InventoryId });
        }

        [HttpDelete("DeleteInventory/{id}")]
        public IActionResult DeleteInventory(long id)
        {
            Inventory inventory = Inv_repo.Find(id);
            if (inventory == null)
            {
                return NotFound();
            }
            Inv_repo.Delete(inventory);
            return Ok();
        }
        #endregion

        #region Inventory Currency
        [HttpGet("GetInventoryCurrencies", Name = "GetInventoryCurrencies")]
        public IEnumerable<InventoryCurrency> GetInventoryCurrencies()
        {
            return Currency_repo.GetAll().OrderByDescending(a => a.InventoryCurrencyId);
            //IEnumerable<Inventory> iv = Inv_repo.GetAll(a => a.InventoryItem);
            //iv = iv.OrderByDescending(a => a.InventoryId);
            //return iv;
        }

        [HttpGet("GetInventoryCurrenciesByCompany/{companyid}", Name = "GetInventoryCurrenciesByCompany")]
        public IEnumerable<InventoryCurrency> GetInventoryCurrenciesByCompany([FromRoute]long companyid)
        {
            return Currency_repo.GetList(a => a.CompanyId == companyid).OrderByDescending(a => a.InventoryCurrencyId);
        }

        [HttpGet("GetInventoryCurrency/{id}", Name = "GetInventoryCurrency")]
        public InventoryCurrency GetInventoryCurrency(long id) => Currency_repo.GetFirst(a => a.InventoryCurrencyId == id);

        [HttpPut("UpdateInventoryCurrency", Name = "UpdateInventoryCurrency")]
        [ValidateModelAttribute]
        public IActionResult UpdateInventoryCurrency([FromBody]InventoryCurrency model)
        {
            Currency_repo.Update(model);
            return new OkObjectResult(new { InventoryCurrencyID = model.InventoryCurrencyId });
        }

        [HttpPost("AddInventoryCurrency", Name = "AddInventoryCurrency")]
        [ValidateModelAttribute]
        public IActionResult AddInventoryCurrency([FromBody]InventoryCurrency model)
        {
            Currency_repo.Add(model);
            return new OkObjectResult(new { InventoryCurrencyID = model.InventoryCurrencyId });
        }

        [HttpDelete("DeleteInventoryCurrency/{id}")]
        public IActionResult DeleteInventoryCurrency(long id)
        {
            InventoryCurrency inventoryCurrency = Currency_repo.Find(id);
            if (inventoryCurrency == null)
            {
                return NotFound();
            }
            Currency_repo.Delete(inventoryCurrency);
            return Ok();
        }
        #endregion

        #region General SKU

        [HttpGet("GetGeneralSKUs", Name = "GetGeneralSKUs")]
        public IEnumerable<GeneralSKU> GetGeneralSKUs()
        {
            return gen_repo.GetAll().ToList().OrderByDescending(a => a.GeneralSKUId);
        }

        [HttpGet("GetGeneralSKUsByCompany/{companyid}", Name = "GetGeneralSKUsByCompany")]
        public IEnumerable<GeneralSKU> GetGeneralSKUsByCompany([FromRoute]long companyid)
        {
            return gen_repo.GetList(a => a.CompanyId != null && a.CompanyId == companyid).OrderByDescending(a => a.GeneralSKUId);
        }

        [HttpGet("GetGeneralSKU/{id}", Name = "GetGeneralSKU")]
        public GeneralSKU GetGeneralSKU([FromRoute]long id)
        {
            return gen_repo.GetFirst(a => a.GeneralSKUId == id);
        }

        [HttpPost("AddGeneralSKU", Name = "AddGeneralSKU")]
        [ValidateModelAttribute]
        public IActionResult AddGeneralSKU([FromBody]GeneralSKU model)
        {
            gen_repo.Add(model);
            return new OkObjectResult(new { GeneralSKUId = model.GeneralSKUId });
        }

        [HttpPut("UpdateGeneralSKU", Name = "UpdateGeneralSKU")]
        [ValidateModelAttribute]
        public IActionResult UpdateGeneralSKU([FromBody]GeneralSKU model)
        {
            gen_repo.Update(model);
            return new OkObjectResult(new { GeneralSKUId = model.GeneralSKUId });
        }

        [HttpDelete("DeleteGeneralSKU/{id}", Name = "DeleteGeneralSKU")]
        public IActionResult DeleteGeneralSKU([FromRoute]long id)
        {
            GeneralSKU gsku = gen_repo.GetFirst(a => a.GeneralSKUId == id);
            if (gsku == null)
            {
                return BadRequest();
            }
            gen_repo.Delete(gsku);
            return Ok();
        }

        #endregion
    }
}
