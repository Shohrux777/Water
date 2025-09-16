using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.bron
{
    [Table("hospital_ochred")]
    public class HospitalOchred : HospitalBaseStandartModel
    {
        public String ochred_name_aout_genereted { get; set; }
        public Patients patients { get; set; }
        public long PatientsId { get; set; }
        public Users users { get; set; }
        public long UsersId { get; set; }
        public DateTime reg_date_ochred { get; set; } = DateTime.Now;
        public bool accepted_status { get; set; } = false;
        public Authorization authorization { get; set; }
        public long AuthorizationId { get; set; }

        [NotMapped]
        public List<Payments> payments_list { get; set; }

        [NotMapped]
        public List<Payments> payments_list_payed { get; set; }

        [NotMapped]
        public List<Payments> payments_list_all { get; set; }
    }
}
