using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.analiz
{
    [Table("hospital_bioximya_krov")]
    public class HospitalBioximyaKrov: HospitalBaseModel
    {
        public String device_name { get; set; }
        public String alt { get; set; }
        public String act { get; set; }
        public String tb { get; set; }
        public String db { get; set; }
        public String tp { get; set; }
        public String glu { get; set; }
        public String krea { get; set; }
        public String bun { get; set; }
        public String tc { get; set; }
        public String hdl_c { get; set; }
        public String ldl_c { get; set; }
        public String ca { get; set; }
        public String amylase { get; set; }

    }
}
