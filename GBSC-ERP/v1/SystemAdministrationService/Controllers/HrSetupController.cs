using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Entities.HR.Attendance.AttendanceSetup;
using ErpCore.Entities.HR.Leave;
using ErpCore.Entities.HR.Leave.LeaveAdmin;
using ErpCore.Entities.HR.Leave.LeaveSetup;
using ErpCore.Entities.HRSetup;
using ErpCore.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemAdministrationService.Repos.Hr.LeaveRepos.Interfaces;
using SystemAdministrationService.Repos.HrSetupRepos.HrSetupInterfaces; 

namespace SystemAdministrationService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class HrSetupController : Controller
    { 
        private IBankRepository Bank_repo;
        private ICostCenterRepository CostCenter_repo;
        private IDegreeRepository Degree_repo;
        private IDesignationRepository Designation_repo;
        private IEmployeeStatusRepository EmpStatus_repo;
        private IEmployeeTypeRepository EmpType_repo;
        private IFunctionRepository Func_repo;
        private IGazettedHolidaysRepository Holiday_repo; 
        private IGroupRepository Group_repo;
        private ILanguageRepository Lang_repo;
        private ILeaveTypeRepository LveType_repo;
        private IManagementLevelRepository MngLvl_repo;
        private IRelationRepository Relation_repo;
        private IReligionRepository Religion_repo; 
        private ISkillLevelRepository SkillLevel_repo;
        private IUniversityRepository Uni_repo;
        private IWorkExperienceRepository wexp_repo;
        private IUserDocumentRepository Doc_repo;
        private IUserPhotoRepository Photo_repo;
        private IUserCompanyRepository UserCompany_repo;
        private IDependantsRelationRepository Dependantsrelation_repo;


        public HrSetupController( 
            IBankRepository repo4,
            ICostCenterRepository repo6,
            IDegreeRepository repo8,
            IDesignationRepository repo9,
            IEmployeeStatusRepository repo10,
            IEmployeeTypeRepository repo11,
            IFunctionRepository repo12,
            IGazettedHolidaysRepository repo13, 
            IGroupRepository repo15,
            ILanguageRepository repo16,
            IManagementLevelRepository repo18,
            IRelationRepository repo20,
            IReligionRepository repo21, 
            ISkillLevelRepository repo24,
            IUniversityRepository repo25,
            IWorkExperienceRepository repo26,
            IUserDocumentRepository repo27,
            IUserPhotoRepository repo28,
            IUserCompanyRepository repo29,
            IDependantsRelationRepository repo30
            
            )
        {
        
            Bank_repo = repo4;
            CostCenter_repo = repo6;
            Degree_repo = repo8;
            Designation_repo = repo9;
            EmpStatus_repo = repo10;
            EmpType_repo = repo11;
            Func_repo = repo12;
            Holiday_repo = repo13; 
            Group_repo = repo15;
            Lang_repo = repo16; 
            MngLvl_repo = repo18;
            Relation_repo = repo20;
            Religion_repo = repo21; 
            SkillLevel_repo = repo24;
            Uni_repo = repo25;
            wexp_repo = repo26;
            Doc_repo = repo27;
            Photo_repo = repo28;
            UserCompany_repo = repo29;
            Dependantsrelation_repo = repo30;
        }
        
        #region Bank
        [HttpGet("GetBanks", Name = "GetBanks")]
        public IEnumerable<Bank> GetBanks()
        {
            return Bank_repo.GetAll().OrderByDescending(a=>a.BankId);
        }

        [HttpGet("GetBank/{id}", Name = "GetBank")]
        public Bank GetBank(long id) => Bank_repo.GetFirst(a => a.BankId == id);

        [HttpPost("AddBank", Name = "AddBank")]
        [ValidateModelAttribute]
        public IActionResult AddBank([FromBody]Bank model)
        {
            Bank_repo.Add(model);
            return new OkObjectResult(new { BankID = model.BankId });
        }

        [HttpPut("UpdateBank", Name = "UpdateBank")]
        [ValidateModelAttribute]
        public IActionResult UpdateBank([FromBody]Bank model)
        {
            Bank_repo.Update(model);
            return new OkObjectResult(new { BankID = model.BankId });
        }

        [HttpDelete("DeleteBank/{id}")]
        public IActionResult DeleteBank(long id)
        {
            Bank a = Bank_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Bank_repo.Delete(a);
            return Ok();
        }
        #endregion
        
        #region Cost Center
        [HttpGet("GetCostCenters", Name = "GetCostCenters")]
        public IEnumerable<CostCenter> GetCostCenters()
        {
            return CostCenter_repo.GetAll().OrderByDescending(a=>a.CostCenterId);
        }

        [HttpGet("GetCostCenter/{id}", Name = "GetCostCenter")]
        public CostCenter GetCostCenter(long id) => CostCenter_repo.GetFirst(a => a.CostCenterId == id);

        [HttpPost("AddCostCenter", Name = "AddCostCenter")]
        [ValidateModelAttribute]
        public IActionResult AddCostCenter([FromBody]CostCenter model)
        {
            CostCenter_repo.Add(model);
            return new OkObjectResult(new { CostCenterID = model.CostCenterId });
        }

        [HttpPut("UpdateCostCenter", Name = "UpdateCostCenter")]
        [ValidateModelAttribute]
        public IActionResult UpdateCostCenter([FromBody]CostCenter model)
        {
            CostCenter_repo.Update(model);
            return new OkObjectResult(new { CostCenterID = model.CostCenterId });
        }

        [HttpDelete("DeleteCostCenter/{id}")]
        public IActionResult DeleteCostCenter(long id)
        {
            CostCenter a = CostCenter_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            CostCenter_repo.Delete(a);
            return Ok();
        }
        #endregion
        
        #region Degree
        [HttpGet("GetDegrees", Name = "GetDegrees")]
        public IEnumerable<Degree> GetDegrees()
        {
            return Degree_repo.GetAll().OrderByDescending(a=>a.DegreeId);
        }

        [HttpGet("GetDegree/{id}", Name = "GetDegree")]
        public Degree GetDegree(long id) => Degree_repo.GetFirst(a => a.DegreeId == id);

        [HttpPost("AddDegree", Name = "AddDegree")]
        [ValidateModelAttribute]
        public IActionResult AddDegree([FromBody]Degree model)
        {
            Degree_repo.Add(model);
            return new OkObjectResult(new { DegreeID = model.DegreeId });
        }

        [HttpPut("UpdateDegree", Name = "UpdateDegree")]
        [ValidateModelAttribute]
        public IActionResult UpdateDegree([FromBody]Degree model)
        {
            Degree_repo.Update(model);
            return new OkObjectResult(new { DegreeID = model.DegreeId });
        }

        [HttpDelete("DeleteDegree/{id}")]
        public IActionResult DeleteDegree(long id)
        {
            Degree a = Degree_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Degree_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region Designation
        [HttpGet("GetDesignations", Name = "GetDesignations")]
        public IEnumerable<Designation> GetDesignations()
        {
            return Designation_repo.GetAll().OrderByDescending(a=>a.DesignationId);
        }

        [HttpGet("GetDesignation/{id}", Name = "GetDesignation")]
        public Designation GetDesignation(long id) => Designation_repo.GetFirst(a => a.DesignationId == id);

        [HttpPost("AddDesignation", Name = "AddDesignation")]
        [ValidateModelAttribute]
        public IActionResult AddDesignation([FromBody]Designation model)
        {
            Designation_repo.Add(model);
            return new OkObjectResult(new { DesignationID = model.DesignationId });
        }

        [HttpPut("UpdateDesignation", Name = "UpdateDesignation")]
        [ValidateModelAttribute]
        public IActionResult UpdateDesignation([FromBody]Designation model)
        {
            Designation_repo.Update(model);
            return new OkObjectResult(new { DesignationID = model.DesignationId });
        }

        [HttpDelete("DeleteDesignation/{id}")]
        public IActionResult DeleteDesignation(long id)
        {
            Designation a = Designation_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Designation_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region Employee Status
        [HttpGet("GetEmployeeStatuses", Name = "GetEmployeeStatuses")]
        public IEnumerable<EmployeeStatus> GetEmployeeStatuses()
        {
            return EmpStatus_repo.GetAll().OrderByDescending(a=>a.EmployeeStatusId);
        }

        [HttpGet("GetEmployeeStatus/{id}", Name = "GetEmployeeStatus")]
        public EmployeeStatus GetEmployeeStatus(long id) => EmpStatus_repo.GetFirst(a => a.EmployeeStatusId == id);

        [HttpPost("AddEmployeeStatus", Name = "AddEmployeeStatus")]
        [ValidateModelAttribute]
        public IActionResult AddEmployeeStatus([FromBody]EmployeeStatus model)
        {
            EmpStatus_repo.Add(model);
            return new OkObjectResult(new { EmployeeStatusID = model.EmployeeStatusId });
        }

        [HttpPut("UpdateEmployeeStatus", Name = "UpdateEmployeeStatus")]
        [ValidateModelAttribute]
        public IActionResult UpdateEmployeeStatus([FromBody]EmployeeStatus model)
        {
            EmpStatus_repo.Update(model);
            return new OkObjectResult(new { EmployeeStatusID = model.EmployeeStatusId });
        }

        [HttpDelete("DeleteEmployeeStatus/{id}")]
        public IActionResult DeleteEmployeeStatus(long id)
        {
            EmployeeStatus a = EmpStatus_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            EmpStatus_repo.Delete(a);
            return Ok();
        }
        #endregion
        
        #region Employee Type
        [HttpGet("GetEmployeeTypes", Name = "GetEmployeeTypes")]
        public IEnumerable<EmployeeType> GetEmployeeTypes()
        {
            return EmpType_repo.GetAll().OrderByDescending(a=>a.EmployeeTypeId);
        }

        [HttpGet("GetEmployeeType/{id}", Name = "GetEmployeeType")]
        public EmployeeType GetEmployeeType(long id) => EmpType_repo.GetFirst(a => a.EmployeeTypeId == id);

        [HttpPost("AddEmployeeType", Name = "AddEmployeeType")]
        [ValidateModelAttribute]
        public IActionResult AddEmployeeType([FromBody]EmployeeType model)
        {
            EmpType_repo.Add(model);
            return new OkObjectResult(new { EmployeeTypeID = model.EmployeeTypeId });
        }

        [HttpPut("UpdateEmployeeType", Name = "UpdateEmployeeType")]
        [ValidateModelAttribute]
        public IActionResult UpdateEmployeeType([FromBody]EmployeeType model)
        {
            EmpType_repo.Update(model);
            return new OkObjectResult(new { EmployeeTypeID = model.EmployeeTypeId });
        }

        [HttpDelete("DeleteEmployeeType/{id}")]
        public IActionResult DeleteEmployeeType(long id)
        {
            EmployeeType a = EmpType_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            EmpType_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region Function
        [HttpGet("GetFunctions", Name = "GetFunctions")]
        public IEnumerable<Function> GetFunctions()
        {
            return Func_repo.GetAll().OrderByDescending(a=>a.FunctionId);
        }

        [HttpGet("GetFunction/{id}", Name = "GetFunction")]
        public Function GetFunction(long id) => Func_repo.GetFirst(a => a.FunctionId == id);

        [HttpPost("AddFunction", Name = "AddFunction")]
        [ValidateModelAttribute]
        public IActionResult AddFunction([FromBody]Function model)
        {
            Func_repo.Add(model);
            return new OkObjectResult(new { FunctionID = model.FunctionId });
        }

        [HttpPut("UpdateFunction", Name = "UpdateFunction")]
        [ValidateModelAttribute]
        public IActionResult UpdateFunction([FromBody]Function model)
        {
            Func_repo.Update(model);
            return new OkObjectResult(new { FunctionID = model.FunctionId });
        }

        [HttpDelete("DeleteFunction/{id}")]
        public IActionResult DeleteFunction(long id)
        {
            Function a = Func_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Func_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region Gazetted Holiday
        [HttpGet("GetHolidays", Name = "GetHolidays")]
        public IEnumerable<GazettedHolidays> GetHolidays()
        {
            return Holiday_repo.GetAll().OrderByDescending(a=>a.GazettedHolidaysId);
        }

        [HttpGet("GetHoliday/{id}", Name = "GetHoliday")]
        public GazettedHolidays GetHoliday(long id) => Holiday_repo.GetFirst(a => a.GazettedHolidaysId == id);

        [HttpPost("AddHoliday", Name = "AddHoliday")]
        [ValidateModelAttribute]
        public IActionResult AddHoliday([FromBody]GazettedHolidays model)
        {
            Holiday_repo.Add(model);
            return new OkObjectResult(new { HolidayID = model.GazettedHolidaysId });
        }

        [HttpPut("UpdateHoliday", Name = "UpdateHoliday")]
        [ValidateModelAttribute]
        public IActionResult UpdateHoliday([FromBody]GazettedHolidays model)
        {
            Holiday_repo.Update(model);
            return new OkObjectResult(new { HolidayID = model.GazettedHolidaysId });
        }

        [HttpDelete("DeleteHoliday/{id}")]
        public IActionResult DeleteHoliday(long id)
        {
            GazettedHolidays a = Holiday_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Holiday_repo.Delete(a);
            return Ok();
        }
        #endregion
        
        #region Group
        [HttpGet("GetGroups", Name = "GetGroups")]
        public IEnumerable<Group> GetGroups()
        {
            return Group_repo.GetAll().OrderByDescending(a=>a.GroupId);
        }

        [HttpGet("GetGroup/{id}", Name = "GetGroup")]
        public Group GetGroup(long id) => Group_repo.GetFirst(a => a.GroupId == id);

        [HttpPost("AddGroup", Name = "AddGroup")]
        [ValidateModelAttribute]
        public IActionResult AddGroup([FromBody]Group model)
        {
            Group_repo.Add(model);
            return new OkObjectResult(new { GroupID = model.GroupId });
        }

        [HttpPut("UpdateGroup", Name = "UpdateGroup")]
        [ValidateModelAttribute]
        public IActionResult UpdateGroup([FromBody]Group model)
        {
            Group_repo.Update(model);
            return new OkObjectResult(new { GroupID = model.GroupId });
        }

        [HttpDelete("DeleteGroup/{id}")]
        public IActionResult DeleteGroup(long id)
        {
            Group a = Group_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Group_repo.Delete(a);
            return Ok();
        }
        #endregion
        
        #region Language
        [HttpGet("GetLanguages", Name = "GetLanguages")]
        public IEnumerable<Language> GetLanguages()
        {
            return Lang_repo.GetAll().OrderByDescending(a=>a.LanguageId);
        }

        [HttpGet("GetLanguage/{id}", Name = "GetLanguage")]
        public Language GetLanguage(long id) => Lang_repo.GetFirst(a => a.LanguageId == id);

        [HttpPost("AddLanguage", Name = "AddLanguage")]
        [ValidateModelAttribute]
        public IActionResult AddLanguage([FromBody]Language model)
        {
            Lang_repo.Add(model);
            return new OkObjectResult(new { LanguageID = model.LanguageId });
        }

        [HttpPut("UpdateLanguage", Name = "UpdateLanguage")]
        [ValidateModelAttribute]
        public IActionResult UpdateLanguage([FromBody]Language model)
        {
            Lang_repo.Update(model);
            return new OkObjectResult(new { LanguageID = model.LanguageId });
        }

        [HttpDelete("DeleteLanguage/{id}")]
        public IActionResult DeleteLanguage(long id)
        {
            Language a = Lang_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Lang_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region Management Level
        [HttpGet("GetManagementLevels", Name = "GetManagementLevels")]
        public IEnumerable<ManagementLevel> GetManagementLevels()
        {
            return MngLvl_repo.GetAll().OrderByDescending(a=>a.ManagementLevelId);
        }

        [HttpGet("GetManagementLevel/{id}", Name = "GetManagementLevel")]
        public ManagementLevel GetManagementLevel(long id) => MngLvl_repo.GetFirst(a => a.ManagementLevelId == id);

        [HttpPost("AddManagementLevel", Name = "AddManagementLevel")]
        [ValidateModelAttribute]
        public IActionResult AddManagementLevel([FromBody]ManagementLevel model)
        {
            MngLvl_repo.Add(model);
            return new OkObjectResult(new { ManagementLevelID = model.ManagementLevelId });
        }

        [HttpPut("UpdateManagementLevel", Name = "UpdateManagementLevel")]
        [ValidateModelAttribute]
        public IActionResult UpdateManagementLevel([FromBody]ManagementLevel model)
        {
            MngLvl_repo.Update(model);
            return new OkObjectResult(new { ManagementLevelID = model.ManagementLevelId });
        }

        [HttpDelete("DeleteManagementLevel/{id}")]
        public IActionResult DeleteManagementLevel(long id)
        {
            ManagementLevel a = MngLvl_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            MngLvl_repo.Delete(a);
            return Ok();
        }
        #endregion
    
        #region Relation
        [HttpGet("GetRelations", Name = "GetRelations")]
        public IEnumerable<Relation> GetRelations()
        {
            return Relation_repo.GetAll().OrderByDescending(a=>a.RelationId);
        }

        [HttpGet("GetRelation/{id}", Name = "GetRelation")]
        public Relation GetRelation(long id) => Relation_repo.GetFirst(a => a.RelationId == id);

        [HttpPost("AddRelation", Name = "AddRelation")]
        [ValidateModelAttribute]
        public IActionResult AddRelation([FromBody]Relation model)
        {
            Relation_repo.Add(model);
            return new OkObjectResult(new { RelationID = model.RelationId });
        }

        [HttpPut("UpdateRelation", Name = "UpdateRelation")]
        [ValidateModelAttribute]
        public IActionResult UpdateRelation([FromBody]Relation model)
        {
            Relation_repo.Update(model);
            return new OkObjectResult(new { RelationID = model.RelationId });
        }

        [HttpDelete("DeleteRelation/{id}")]
        public IActionResult DeleteRelation(long id)
        {
            Relation a = Relation_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Relation_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region DependantsRelation
        [HttpGet("GetDependantsRelations", Name = "GetDependantsRelations")]
        public IEnumerable<DependantsRelation> GetDependantsRelations()
        {
            return Dependantsrelation_repo.GetAll().OrderByDescending(a => a.DependantsRelationId);
        }

        [HttpGet("GetDependantsRelation/{id}", Name = "GetDependantsRelation")]
        public DependantsRelation GetDependantsRelation(long id) => Dependantsrelation_repo.GetFirst(a => a.DependantsRelationId == id);

        [HttpPost("AddDependantsRelation", Name = "AddDependantsRelation")]
        [ValidateModelAttribute]
        public IActionResult AddDependantsRelation([FromBody]DependantsRelation model)
        {
            Dependantsrelation_repo.Add(model);
            return new OkObjectResult(new { DependantsRelationID = model.DependantsRelationId });
        }

        [HttpPut("UpdateDependantsRelation", Name = "UpdateDependantsRelation")]
        [ValidateModelAttribute]
        public IActionResult UpdateRelation([FromBody]DependantsRelation model)
        {
            Dependantsrelation_repo.Update(model);
            return new OkObjectResult(new { DependantRelationID = model.DependantsRelationId });
        }

        [HttpDelete("DeleteDependantsRelation/{id}")]
        public IActionResult DeleteDependantsRelation(long id)
        {
            DependantsRelation a = Dependantsrelation_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Dependantsrelation_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Religion
        [HttpGet("GetReligions", Name = "GetReligions")]
        public IEnumerable<Religion> GetReligions()
        {
            return Religion_repo.GetAll().OrderByDescending(a=>a.ReligionId);
        }

        [HttpGet("GetReligion/{id}", Name = "GetReligion")]
        public Religion GetReligion(long id) => Religion_repo.GetFirst(a => a.ReligionId == id);

        [HttpPost("AddReligion", Name = "AddReligion")]
        [ValidateModelAttribute]
        public IActionResult AddReligion([FromBody]Religion model)
        {
            Religion_repo.Add(model);
            return new OkObjectResult(new { ReligionID = model.ReligionId });
        }

        [HttpPut("UpdateReligion", Name = "UpdateReligion")]
        [ValidateModelAttribute]
        public IActionResult UpdateReligion([FromBody]Religion model)
        {
            Religion_repo.Update(model);
            return new OkObjectResult(new { ReligionID = model.ReligionId });
        }

        [HttpDelete("DeleteReligion/{id}")]
        public IActionResult DeleteReligion(long id)
        {
            Religion a = Religion_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Religion_repo.Delete(a);
            return Ok();
        }
        #endregion
        
        #region Skill Level
        [HttpGet("GetSkillLevels", Name = "GetSkillLevels")]
        public IEnumerable<SkillLevel> GetSkillLevels()
        {
            return SkillLevel_repo.GetAll().OrderByDescending(a=>a.SkillLevelId);
        }

        [HttpGet("GetSkillLevel/{id}", Name = "GetSkillLevel")]
        public SkillLevel GetSkillLevel(long id) => SkillLevel_repo.GetFirst(a => a.SkillLevelId == id);

        [HttpPost("AddSkillLevel", Name = "AddSkillLevel")]
        [ValidateModelAttribute]
        public IActionResult AddSkillLevel([FromBody]SkillLevel model)
        {
            SkillLevel_repo.Add(model);
            return new OkObjectResult(new { SkillLevelID = model.SkillLevelId });
        }

        [HttpPut("UpdateSkillLevel", Name = "UpdateSkillLevel")]
        [ValidateModelAttribute]
        public IActionResult UpdateSkillLevel([FromBody]SkillLevel model)
        {
            SkillLevel_repo.Update(model);
            return new OkObjectResult(new { SkillLevelID = model.SkillLevelId });
        }

        [HttpDelete("DeleteSkillLevel/{id}")]
        public IActionResult DeleteSkillLevel(long id)
        {
            SkillLevel a = SkillLevel_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            SkillLevel_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region University
        [HttpGet("GetUniversities", Name = "GetUniversities")]
        public IEnumerable<University> GetUniversities()
        {
            return Uni_repo.GetAll().OrderByDescending(a=>a.UniversityId);
        }

        [HttpGet("GetUniversity/{id}", Name = "GetUniversity")]
        public University GetUniversity(long id) => Uni_repo.GetFirst(a => a.UniversityId == id);

        [HttpPost("AddUniversity", Name = "AddUniversity")]
        [ValidateModelAttribute]
        public IActionResult AddUniversity([FromBody]University model)
        {
            Uni_repo.Add(model);
            return new OkObjectResult(new { UniversityID = model.UniversityId });
        }

        [HttpPut("UpdateUniversity", Name = "UpdateUniversity")]
        [ValidateModelAttribute]
        public IActionResult UpdateUniversity([FromBody]University model)                                                               
        {
            Uni_repo.Update(model);
            return new OkObjectResult(new { UniversitylID = model.UniversityId });
        }

        [HttpDelete("DeleteUniversity/{id}")]
        public IActionResult DeleteUniversity(long id)
        {
            University a = Uni_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Uni_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region Work Experience
        [HttpGet("GetWorkExperiences", Name = "GetWorkExperiences")]
        public IEnumerable<WorkExperience> GetWorkExperiences()
        {
            return wexp_repo.GetAll().OrderByDescending(a=>a.WorkExperienceId);
        }

        [HttpGet("GetWorkExperience/{id}", Name = "GetWorkExperience")]
        public WorkExperience GetWorkExperience(long id) => wexp_repo.GetFirst(a => a.WorkExperienceId == id);

        [HttpPost("AddWorkExperience", Name = "AddWorkExperience")]
        [ValidateModelAttribute]
        public IActionResult AddWorkExperience([FromBody]WorkExperience model)
        {
            wexp_repo.Add(model);
            return new OkObjectResult(new { WorkExpID = model.WorkExperienceId });
        }

        [HttpPut("UpdateWorkExperience", Name = "UpdateWorkExperience")]
        [ValidateModelAttribute]
        public IActionResult UpdateWorkExperience([FromBody]WorkExperience model)
        {
            wexp_repo.Update(model);
            return new OkObjectResult(new { WorkExperienceID = model.WorkExperienceId });
        }

        [HttpDelete("DeleteWorkExperience/{id}")]
        public IActionResult DeleteWorkExperience(long id)
        {
            WorkExperience a = wexp_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            wexp_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region User Documents
        [HttpGet("GetUserDocuments", Name = "GetUserDocuments")]
        public IEnumerable<UserDocument> GetUserDocuments()
        {
            return Doc_repo.GetAll().OrderByDescending(a=>a.UserDocumentId);
        }

        [HttpGet("GetUserDocument/{id}", Name = "GetUserDocument")]
        public UserDocument GetUserDocument(long id) => Doc_repo.GetFirst(a => a.UserDocumentId == id);

        [HttpPost("AddUserDocument", Name = "AddUserDocument")]
        [ValidateModelAttribute]
        public IActionResult AddUserDocument([FromBody]UserDocument model)
        {
            Doc_repo.Add(model);
            return new OkObjectResult(new { UserDocumentID = model.UserDocumentId });
        }

        [HttpPut("UpdateUserDocument", Name = "UpdateUserDocument")]
        [ValidateModelAttribute]
        public IActionResult UpdateUserDocument([FromBody]UserDocument model)
        {
            Doc_repo.Update(model);
            return new OkObjectResult(new { UserDocumentID = model.UserDocumentId });
        }

        [HttpDelete("DeleteUserDocument/{id}")]
        public IActionResult DeleteUserDocument(long id)
        {
            UserDocument a = Doc_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Doc_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region User Photos
        [HttpGet("GetUserPhotos", Name = "GetUserPhotos")]
        public IEnumerable<UserPhoto> GetUserPhotos()
        {
            return Photo_repo.GetAll().OrderByDescending(a=>a.UserPhotoId);
        }

        [HttpGet("GetUserPhoto/{id}", Name = "GetUserPhoto")]
        public UserPhoto GetUserPhoto(long id) => Photo_repo.GetFirst(a => a.UserPhotoId == id);

        [HttpPost("AddUserPhoto", Name = "AddUserPhoto")]
        [ValidateModelAttribute]
        public IActionResult AddUserPhoto([FromBody]UserPhoto model)
        {
            Photo_repo.Add(model);
            return new OkObjectResult(new { UserPhotoID = model.UserPhotoId });
        }
        
        [HttpPut("UpdateUserPhoto", Name = "UpdateUserPhoto")]
        [ValidateModelAttribute]
        public IActionResult UpdateUserPhoto([FromBody]UserPhoto model)
        {
            Photo_repo.Update(model);
            return new OkObjectResult(new { UserPhotoID = model.UserPhotoId });
        }

        [HttpDelete("DeleteUserPhoto/{id}")]
        public IActionResult DeleteUserPhoto(long id)
        {
            UserPhoto a = Photo_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Photo_repo.Delete(a);
            return Ok();
        }
        #endregion
         
        #region User Company
        [HttpGet("GetUserCompanies", Name = "GetUserCompanies")]
        public IEnumerable<UserCompany> GetUserCompanies()
        {
            return UserCompany_repo.GetAll(a => a.Designation).OrderByDescending(a=>a.UserCompanyId);
        }

        [HttpGet("GetUserCompany/{id}", Name = "GetUserCompany")]
        public UserCompany GetUserCompany(long id) => UserCompany_repo.GetFirst(a => a.UserCompanyId == id, b => b.Designation);

        [HttpPost("AddUserCompany", Name = "AddUserCompany")]
        [ValidateModelAttribute]
        public IActionResult AddUserCompany([FromBody]UserCompany model)
        {
            UserCompany_repo.Add(model);
            return new OkObjectResult(new { UserCompanyID = model.UserCompanyId });
        }

        [HttpPut("UpdateHrUserCompany", Name = "UpdateHrUserCompany")]
        [ValidateModelAttribute]
        public IActionResult UpdateHrUserCompany([FromBody]UserCompany model)
        {
            UserCompany_repo.Update(model);
            return new OkObjectResult(new { UserCompanylID = model.UserCompanyId });
        }

        [HttpDelete("DeleteUserCompany/{id}")]
        public IActionResult DeleteUserCompany(long id)
        {
            UserCompany a = UserCompany_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            UserCompany_repo.Delete(a);
            return Ok();
        }
        #endregion
    }
}
