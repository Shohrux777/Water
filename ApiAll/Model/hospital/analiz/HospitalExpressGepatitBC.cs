using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.analiz
{
    [Table("hospital_express_gepatit_bc")]
    public class HospitalExpressGepatitBC : HospitalBaseModel
    {
        public String gepatit_b { get; set; }
        public String gepatit_c { get; set; }
    }
}
