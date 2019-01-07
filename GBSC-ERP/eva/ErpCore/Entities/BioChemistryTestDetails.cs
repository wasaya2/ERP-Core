using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class BioChemistryTestDetails : BaseClass
    {


        [Key]
        public long BioChemistryTestDetailsId { get; set; }
        public string LogicalOperator { get; set; }
        public string Result { get; set; }
        public bool? IsReChecked { get; set; }
        public string Remarks { get; set; }

        public long? BioChemistryTestId { get; set; }
        public BioChemistryTest BioChemistryTest { get; set; }

        public long? TestUnitId { get; set; }
        public TestUnit TestUnit { get; set; }

        public long? PatientBioChemistryTestId { get; set; }
        public BioChemistryTestOnTreatment BioChemistryTestOnTreatment { get; set; }

        public long? BioChemistryTestOutsideId { get; set; }

        public BioChemistryTestOutsider BioChemistryTestOutsider { get; set; }

    }
}
