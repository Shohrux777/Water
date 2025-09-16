using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital
{
    [Table("hospital_patient_analiz_history")]
    public class HospitalPatientAnalizHistory : HospitalBaseModel
    {
        public String analiz_name { get; set; }
        public String analiz_file_name{get;set;}
        public DateTime date_time_reg { get; set; } = DateTime.Now;
        public DateTime date_time_analiz_get { get; set; } = DateTime.Now;
        public String analiz_base_str { get; set; }
       
    }
}
