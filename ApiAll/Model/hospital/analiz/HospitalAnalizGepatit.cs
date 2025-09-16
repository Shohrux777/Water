using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital
{
    [Table("hospital_analiz_gepatit")]
    public class HospitalAnalizGepatit: HospitalBaseModel
    {
        public String hav { get; set; }
        public String hsg { get; set; }
    }
}
