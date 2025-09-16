using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class HospitalMrtSorovNoma : BaseModel
    {
        public String patientFio { get; set; }
        public DateTime dateOfBirthday { get; set; }
        public String phoneNumber { get; set; }
        public String contragentName { get; set; }
        public String contragentPhoneNumber { get; set; }
        public String address { get; set; }
        public bool kardioSimulator { get; set; }
        public bool eshitishAparatiImplanti { get; set; }
        public bool kozdagiYotMetal { get; set; }
        public bool neyrosimulator { get; set; }
        public bool insulinliPompa { get; set; }
        public bool qontomirStentlari { get; set; }
        public bool protezlar { get; set; }
        public bool xomiladorlikUchOyligi { get; set; }
        public bool umurtqaPogonasidaMetalFixsator { get; set; }
        public bool breketlar { get; set; }
        public bool tutqonoqOtkazganmisz { get; set; }
        public bool nurTerapiya { get; set; }
        public bool ximiyaTerapiya { get; set; }
        public String jarohatOlganmisz { get; set; }
        public String shikoyatlaringz { get; set; }
        public String tekshiriladigonAzolar { get; set; }
        public double summa { get; set; }
        public long ContragentId{get;set;}
        public Contragent contragent { get; set; }
        public long PatientsId{get;set;}
        public Patients patients { get; set; }
        public DateTime createdDateTime { get; set; }
        [NotMapped]
        public String contragent_name => contragent != null ? contragent.Name : "";
        [NotMapped]
        public String patient_name => patients != null ? patients.FIO : "";

    }
}
