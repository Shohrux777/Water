using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital
{

    [Table("hospital_dolg_inv")]
    public class HospitalPatientDolg : HospitalBaseModel
    {
        public long qty { get; set; } = 0;
        public long  real_qty { get; set; } = 0;

        [NotMapped]
        public long summ_dolg => qty;
        [NotMapped]
        public long sum_qoldiq_dolg => real_qty;
    }
}
