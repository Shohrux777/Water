using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.bron
{
    public class HospitalOchredByDocotors
    {
         public long? UsersId { get; set; }

        [NotMapped]
        public Users users { get; set; }

        [NotMapped]
        public List<HospitalOchred> ochred_list { get; set; }
    }
}
