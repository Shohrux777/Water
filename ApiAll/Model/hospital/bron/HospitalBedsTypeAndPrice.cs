using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.bron
{
    [Table("hospital_beds_type_and_summ")]
    public class HospitalBedsTypeAndPrice : HospitalBaseStandartModel
    {
        public double sum { get; set; } = 0.0;
        public double discount_sum { get; set; } = 0.0;
        public String name { get; set; }
        public bool patient_or_not { get; set; } = true;
        public List<long> rooms_id_list { get; set; }
        public String note { get; set; }
        public int days_count { get; set; } = 0;

        
       
    }
}
