using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.hospital
{

    [Table("hospital_bron_room")]
    public class HospitalBronRooms: HospitalBaseStandartModel
    {
        public String room_name { get; set; }
        public String room_type { get; set; }
        public int room_beds_count { get; set; } = 0;
        public String note { get; set; }
    }
}
