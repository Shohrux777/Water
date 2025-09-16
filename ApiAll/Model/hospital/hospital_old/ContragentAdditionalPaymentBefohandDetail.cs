using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class ContragentAdditionalPaymentBefohandDetail : BaseModel
    {
        public DateTime createdDateTime { get; set; }
        public long ContragentId { get; set; }
        public Contragent contragent { get; set; }
        public double summa { get; set; }
        public long PatientsId { get; set; }
        public Patients patients { get; set; }
        public long ServiceTypeId{get;set;}
        public ServiceType serviceType { get; set; }
        public double limitSummLeft { get; set; }
        [NotMapped]
        public String contragent_name => contragent != null ? contragent.Name : "";
        [NotMapped]
        public String patient_name => patients != null ? patients.FIO : "";
        [NotMapped]
        public String service_type_name => serviceType != null ? serviceType.Name : "";



    }
}
