using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.analiz
{
    [Table("hospital_gepatit_bc")]
    public class HospitalGepatitBC:HospitalBaseModel
    {
        public String device_name { get; set; }
        public String hbsag { get; set; }
        public String anti_hgv { get; set; }
        public String a { get; set; }
        public String b { get; set; }
        public String c { get; set; }
        public String d { get; set; }
        public String note { get; set; }
    }
}
