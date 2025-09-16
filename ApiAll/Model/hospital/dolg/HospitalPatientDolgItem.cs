using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital
{

    [Table("hospital_dolg_inv_item")]
    public class HospitalPatientDolgItem : HospitalBaseModel
    {
        public double qty { get; set; } = 0;
        public double real_qty { get; set; } = 0;
        public HospitalPatientDolg dolg { get; set; }
        public long HospitalPatientDolgid {get;set;}
    }
}
