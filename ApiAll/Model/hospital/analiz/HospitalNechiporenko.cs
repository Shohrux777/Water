using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.analiz
{
    [Table("hospital_nechiporenko")]
    public class HospitalNechiporenko: HospitalBaseModel
    {
        public String device_name { get; set; }
        public String leykositi { get; set; }
        public String eritrositi { get; set; }
        public String silindri { get; set; }
       
    }
}
