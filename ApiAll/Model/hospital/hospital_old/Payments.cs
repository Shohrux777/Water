using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class Payments : BaseModel
    {
        public String Name { get; set; }
        public String ServiceName { get; set; }
        public String PatientName { get; set; }
        public long ServiceTypeId { get; set; }
        public ServiceType serviceType { get; set; }
        public long Summ { get; set; }
        public long ReserveSumm { get; set; }
        public long PaymentInCash { get; set; }
        public long PaymentInCard { get; set; }
        public long PatientsId { get; set; }
        public Patients patients { get; set; }
        [DefaultValue(false)]
        public bool Finish { get; set; } = false;
        public long AuthorizationId { get; set; }
        public Authorization authorization { get; set; }
        public long ContragentId { get; set; }
        public Contragent contragent { get; set; }
        [DefaultValue("getutcdate()")]
        public DateTime RegistratedDate { get; set; } = DateTime.Now;
        public bool FinishPayment { get; set; }
        public DateTime acceptanceDateTime { get; set; }
        public DateTime PayedDate { get; set; } = DateTime.Now;
        public long? creatorAuthId { get; set; } 

    }
}
