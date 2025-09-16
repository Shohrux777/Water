using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class PatientRegistrationInfo : BaseModel
    {
        public String ReasonPatient { get; set; }
        public long PatientServiceTypeId { get; set; }
        public PatientServiceType patientServiceType { get; set; }
        public long PatientTypeId { get; set; }
        public PatientType patientType { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public long PatientsId{get;set;}
        public Patients patients { get; set; }

    }
}
