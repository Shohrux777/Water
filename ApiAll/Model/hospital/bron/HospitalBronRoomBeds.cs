using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.hospital
{

    [Table("hospital_bron_room_bed")]
    public class HospitalBronRoomBeds: HospitalBaseStandartModel
    {
        public String beds_name { get; set; }
        public String beds_type { get; set; }
    }
}
