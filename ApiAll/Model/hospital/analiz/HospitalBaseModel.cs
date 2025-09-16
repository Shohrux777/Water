using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.hospital
{
    public class HospitalBaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [DefaultValue(true)]
        public bool active_status { get; set; } = true;
        public DateTime created_date_time { get; set; } = DateTime.Now;
        public DateTime updated_date_time { get; set; } = DateTime.Now;
        public long PatientsId { get; set; }
        public Patients patients { get; set; }
        public String doctor_name { get; set; }
        public String creator_doctor_name { get; set; }
        public bool sended_status { get; set; } = false;

        [NotMapped]
        public String patient_name => patients != null ? patients.FIO : "";


    }
}
