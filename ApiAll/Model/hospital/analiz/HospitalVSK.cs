using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.analiz
{
    [Table("hospital_vsk")]
    public class HospitalVSK:HospitalBaseModel
    {
        public String device_name { get; set; }
        public String h { get; set; }
        public String k { get; set; }
    }
}
