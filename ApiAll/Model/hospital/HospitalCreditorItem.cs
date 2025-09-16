using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital
{
    [Table("hospital_creditor_inv_item")]
    public class HospitalCreditorItem : HospitalBaseModel
    {
        public long HospitalCreditorid { get; set; }
        public HospitalCreditor hospitalCreditor { get; set; }
        public DateTime reg_date { get; set; } = DateTime.Now;
        public double summ { get; set; }
        public String note { get; set; }
        public String real_patient_name { get; set; }
        public String user_name { get; set; }
    }
}
