using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class HospitalRegistrationPermissionDoctors : BaseModel
    {
        public long registraterAuthId { get; set; }

        [ForeignKey("registraterAuthId")]
        public Authorization registraterAuth { get; set; }
        public long doctorAuthId { get; set; }

        [ForeignKey("doctorAuthId")]
        public Authorization doctorAuth { get; set; }

        [NotMapped]
        public String user_name { get; set; }
        [NotMapped]
        public String department_name { get; set; }
        [NotMapped]
        public String position_name { get; set;}
    }
}
