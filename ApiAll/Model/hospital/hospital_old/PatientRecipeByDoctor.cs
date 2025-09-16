using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class PatientRecipeByDoctor : BaseModel
    {
        public String patinetRecipeStr { get; set; }
        public String patientRecipeTitle { get; set; }
        public long DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Users users { get; set; }
        public long PatientsId{get;set;}
        public Patients patients { get; set; }
        public DateTime registratedDate { get; set; }

    }
}
