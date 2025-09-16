using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital
{
    [Table("hospital_patient_messgae_history")]
    public class HospitalPatientMessageHistory : HospitalBaseModel
    {
        public String message_name { get; set; }
        public String message_file_name { get; set; }
        public DateTime date_time_reg { get; set; } = DateTime.Now;
        public DateTime date_time_analiz_get { get; set; } = DateTime.Now;
        public String message_base_str { get; set; }
        
    }
}
