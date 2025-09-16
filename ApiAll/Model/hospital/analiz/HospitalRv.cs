using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.analiz
{
    [Table("hospital_rv")]
    public class HospitalRv:HospitalBaseModel
    {
        public String device_name { get; set; }
        [Required]
        public String syplhilis_rpr { get; set; }

    }
}
