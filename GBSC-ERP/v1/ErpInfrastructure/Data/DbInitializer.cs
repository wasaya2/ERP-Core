using ErpCore.Entities;
using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpInfrastructure.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Companies.Any())
            {
                return;
            }

            List<Company> companies = new List<Company>
            {
                new Company { Name = "1", NumberOfEmployees = 10 },
                new Company { Name = "2", NumberOfEmployees = 20 },
                new Company { Name = "3", NumberOfEmployees = 30 },
                new Company { Name = "4", NumberOfEmployees = 40 }
            };

            context.Companies.AddRange(companies);

            List<Role> roles = new List<Role>
            {
                new Role { Name= "1" },
                new Role { Name= "2" },
                new Role { Name= "3" },
                new Role { Name= "4" }
            };

            context.Roles.AddRange(roles);

            List<Feature> features = new List<Feature>
            {
                new Feature{ Code = "1", Name = "1" },
                new Feature{ Code = "2", Name = "2" },
                new Feature{ Code = "3", Name = "3" },
                new Feature{ Code = "4", Name = "4" }
            };

            context.Features.AddRange(features);

            List<User> users = new List<User>
            {
                new User{ FirstName = "1", LastName = "11", CNIC = "111", Email = "1111" },
                new User{ FirstName = "2", LastName = "22", CNIC = "222", Email = "2222" },
                new User{ FirstName = "3", LastName = "33", CNIC = "333", Email = "3333" },
                new User{ FirstName = "4", LastName = "44", CNIC = "444", Email = "4444" }
            };

            context.Users.AddRange(users);

            List<Patient> patients = new List<Patient>
            {
                new Patient{FirstName = "hamza1", MiddleName = "ali1", LastName = "khan1", DOB = DateTime.Now, Gender = "male", PhoneNumber = "034536547891", Country = "abc", City = "abc" ,State = "abc" ,PostalCode = "12312" ,MRN = "MRN00001", Partner = new Partner{ FirstName = "kjskxv", MiddleName = "oiewroiwe", LastName = "kslasf", FullName = "lksfjas", DOB = DateTime.Now, PlaceOfBirth = "lksjf" } },
                new Patient{FirstName = "hamza2", MiddleName = "ali2", LastName = "khan2", DOB = DateTime.Now, Gender = "female", PhoneNumber = "034536547892", Country = "abc", City = "abc" ,State = "abc" ,PostalCode = "12312" ,MRN = "MRN00002", Partner = new Partner{ FirstName = "bxkv", MiddleName = "osif", LastName = "ojslkvn,mc", FullName = "lipovsd", DOB = DateTime.Now, PlaceOfBirth = "aksuf" } },
                new Patient{FirstName = "hamza3", MiddleName = "ali3", LastName = "khan3", DOB = DateTime.Now, Gender = "male", PhoneNumber = "034536547893", Country = "abc", City = "abc" ,State = "abc" ,PostalCode = "12312" ,MRN = "MRN00003", Partner = new Partner{ FirstName = "mnbbmmx", MiddleName = ",mmxnv", LastName = "n,mcnv", FullName = "iusif", DOB = DateTime.Now, PlaceOfBirth = "al;asd" } },
                new Patient{FirstName = "hamza4", MiddleName = "ali4", LastName = "khan4", DOB = DateTime.Now, Gender = "female", PhoneNumber = "034536547894", Country = "abc", City = "abc" ,State = "abc" ,PostalCode = "12312" ,MRN = "MRN00004", Partner = new Partner{ FirstName = "bvm.zx", MiddleName = "pouiy", LastName = "mnbvo", FullName = "uysf", DOB = DateTime.Now, PlaceOfBirth = "asfs" } }
            };

            context.Patients.AddRange(patients);

            List<PatientInvoice> patientInvoices = new List<PatientInvoice>
            {
                new PatientInvoice{ SlipNumber = "PSN000001", DateCreated = DateTime.Now, InvoiceType = "XYZ", InvoiceRemarks = "HDIV", Consultant = "JDIV", PaymentMethod = "&TYI", ChequeNumber = "HV", Bank = "BCII"},
                new PatientInvoice{ SlipNumber = "PSN000002", DateCreated = DateTime.Now, InvoiceType = "XYZ", InvoiceRemarks = "HDIV", Consultant = "JDIV", PaymentMethod = "&TYI", ChequeNumber = "H(V", Bank = "2BCII"},
                new PatientInvoice{ SlipNumber = "PSN000003", DateCreated = DateTime.Now, InvoiceType = "XYZ", InvoiceRemarks = "HDIV", Consultant = "JDIV", PaymentMethod = "&TYI", ChequeNumber = "H(V", Bank = "3BCII"},
                new PatientInvoice{ SlipNumber = "PSN000004", DateCreated = DateTime.Now, InvoiceType = "XYZ", InvoiceRemarks = "HDIV", Consultant = "JDIV", PaymentMethod = "&TYI", ChequeNumber = "H(V", Bank = "4BCII"},
            };

            context.PatientInvoices.AddRange(patientInvoices);

            List<Appointment> appointments = new List<Appointment>
            {
                new Appointment{ PatientType = "1", TentativeTime = DateTime.Now, FinalTime = DateTime.Now, TimeIn = DateTime.Now, TimeOut = DateTime.Now, VisitStatus = "11", AppointmentDay = "1111", Remarks = "11111"},
                new Appointment{ PatientType = "2", TentativeTime = DateTime.Now, FinalTime = DateTime.Now, TimeIn = DateTime.Now, TimeOut = DateTime.Now, VisitStatus = "22", AppointmentDay = "2222", Remarks = "22222"},
                new Appointment{ PatientType = "3", TentativeTime = DateTime.Now, FinalTime = DateTime.Now, TimeIn = DateTime.Now, TimeOut = DateTime.Now, VisitStatus = "33", AppointmentDay = "3333", Remarks = "33333"},
                new Appointment{ PatientType = "4", TentativeTime = DateTime.Now, FinalTime = DateTime.Now, TimeIn = DateTime.Now, TimeOut = DateTime.Now, VisitStatus = "44", AppointmentDay = "4444", Remarks = "44444"}
            };

            context.Appointments.AddRange(appointments);

            List<PurchaseOrder> purchaseOrders = new List<PurchaseOrder>
            {
                new PurchaseOrder{OrderNumber = "PON0000001", OrderDate = DateTime.Now, OrderRemarks = "1", OrderType = "11"},
                new PurchaseOrder{OrderNumber = "PON0000002", OrderDate = DateTime.Now, OrderRemarks = "2", OrderType = "22"},
                new PurchaseOrder{OrderNumber = "PON0000003", OrderDate = DateTime.Now, OrderRemarks = "3", OrderType = "33"},
                new PurchaseOrder{OrderNumber = "PON0000004", OrderDate = DateTime.Now, OrderRemarks = "4", OrderType = "44"}
            };
            //context.PurchaseOrders.AddRange(purchaseOrders);

            List<Supplier> suppliers = new List<Supplier>
            {
                 new Supplier{ Name = "111", Code = "SC00001", Status = "1111", Address = "11111", City = "111111", Country = "1111111", LandlineNumber = "11111111", MobilerNumber = "111111111", FaxNumber = "1111111111", Email = "11111111111", Nature = "111111111111", ContactName = "1111111111111", ContactNumber = "11111111111111", GlAccount = "111111111111111" },
                 new Supplier{ Name = "222", Code = "SC00002", Status = "2222", Address = "22222", City = "222222", Country = "2222222", LandlineNumber = "22222222", MobilerNumber = "222222222", FaxNumber = "2222222222", Email = "22222222222", Nature = "222222222222", ContactName = "2222222222222", ContactNumber = "22222222222222", GlAccount = "222222222222222" },
                 new Supplier{ Name = "333", Code = "SC00003", Status = "3333", Address = "33333", City = "333333", Country = "3333333", LandlineNumber = "33333333", MobilerNumber = "333333333", FaxNumber = "3333333333", Email = "33333333333", Nature = "333333333333", ContactName = "3333333333333", ContactNumber = "33333333333333", GlAccount = "333333333333333" },
                 new Supplier{ Name = "444", Code = "SC00004", Status = "4444", Address = "44444", City = "444444", Country = "4444444", LandlineNumber = "44444444", MobilerNumber = "444444444", FaxNumber = "4444444444", Email = "44444444444", Nature = "444444444444", ContactName = "4444444444444", ContactNumber = "44444444444444", GlAccount = "444444444444444" }
            };
            context.Suppliers.AddRange(suppliers);

            List<GRN> grns = new List<GRN>
            {
                new GRN{ GrnNumber = "GRN000001"},
                new GRN{ GrnNumber = "GRN000002"},
                new GRN{ GrnNumber = "GRN000003"},
                new GRN{ GrnNumber = "GRN000004"}
            };

            context.GRNs.AddRange(grns);

            context.SaveChanges();
        }


    }
}
