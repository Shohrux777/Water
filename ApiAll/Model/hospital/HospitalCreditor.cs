using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital
{
    [Table("hospital_creditor_inv")]
    public class HospitalCreditor: HospitalBaseModel
    {
        public double sum { get; set; }
        public double real_sum { get; set; }
        public DateTime reg_date { get; set; } = DateTime.Now;
        public String real_patient_name { get; set; }
        public String note { get; set; }
        public String service_name { get; set; }
        public DateTime finish_date_time { get; set; } = DateTime.Now;
        public long ServiceTypeId { get; set; }
        public ServiceType serviceType { get; set; }
        public long AuthorizationId { get; set; }
        public Authorization authorization { get; set; }
        public long ContragentId { get; set; }
        public Contragent contragent { get; set; }
        public List<HospitalCreditorItem> item_list { get; set; }

    }
}
