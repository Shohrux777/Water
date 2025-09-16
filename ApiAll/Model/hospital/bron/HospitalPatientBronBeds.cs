using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.hospital
{

    [Table("hospital_patient_bron_room_bed")]
    public class HospitalPatientBronBeds:HospitalBaseStandartModel
    {
        public long HospitalBronRoomBedsid { get; set; }
        public HospitalBronRoomBeds bed { get; set; }
        public DateTime begin_date { get; set; }
        public DateTime end_date { get; set; }
        public long PatientsId { get; set; }
        public Patients patient { get; set;  }
        public bool free_status { get; set; }
        public String registrator_name { get; set; }
        public String note { get; set; }
        public long AuthorizationId { get; set; }
        public Authorization authorization { get; set; }
        public DateTime reg_date { get; set; } = DateTime.Now;
      

    }
}
