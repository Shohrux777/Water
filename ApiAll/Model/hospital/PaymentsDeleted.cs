using ApiAll.Model;
using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital
{
    [Table("payments_deleted")]
    public class PaymentsDeleted : BaseModel
    {
        public string deleted_user_name { get; set; }
        public string Name { get; set; }
        public string ServiceName { get; set; }
        public string PatientName { get; set; }
        public long ServiceTypeId { get; set; }
        public ServiceType serviceType { get; set; }
        public long Summ { get; set; } = 0;
        public long ReserveSumm { get; set; } = 0;
        public long PaymentInCash { get; set; } = 0;
        public long PaymentInCard { get; set; } = 0;
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

        public long dletedAuthId { get; set; }

        public DateTime deleted_date_time { get; set; } = DateTime.Now;
    }
}
