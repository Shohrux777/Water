using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.dolg
{

    [Table("hospital_patinet_dolg_payments_history")]
    public class HospitalPatientDolgPaymentsHistory : HospitalBaseModel
    {
        public long AuthorizationId { get; set; }
        public Authorization authorization { get; set; }
        public long summ { get; set; }
        public bool card_or_credit { get; set; }
    }

}
