using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital
{
    [Table("hospital_check_patient")]
    public class HospitalCheckPatient: HospitalBaseModel
    {
        public List<long> payments_ids_list { get; set; }
        public String real_patient_name { get; set; }
        public DateTime reg_date { get; set; } = DateTime.Now;
        public bool close_status { get; set; } = false;
        public long summ { get; set; }
        public long auth_id { get; set; }
        [NotMapped]
        public List<Payments> payed_paymnets { get; set; }
        [NotMapped]
        public List<Payments> unpayed_paymnets { get; set; }

        [NotMapped]
        public List<Payments> allpayed_paymnets { get; set; }


    }
}
