using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.reports
{
    [Table("hospital_doctor_earned_report")]
    public class HospitalDoctorsEarnedMoneyReport
    {
        public String pos_name { get; set; }
        public String fio { get; set; }
        public long? summ { get; set; }
        public long? cash { get; set; }
        public long? card { get; set; }
        public long? real_summ { get; set; }
        public long? dolg_summ { get; set; }
    }
}
