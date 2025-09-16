using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.analiz
{
    [Table("hospital_onkomarker")]
    public class HospitalOnkomarker : HospitalBaseModel
    {
        public String device_name { get; set; }
        public String pca { get; set; }
        public String ca_15_3 { get; set; }
        public String ca_125 { get; set; }
    }
}
