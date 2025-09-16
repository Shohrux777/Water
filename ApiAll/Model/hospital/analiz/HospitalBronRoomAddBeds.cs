using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.hospital.analiz
{

    [Table("hospital_bron_room_add_bed")]
    public class HospitalBronRoomAddBeds : HospitalBaseStandartModel
    {
        public long HospitalBronRoomBedsid { get; set; }
        public HospitalBronRoomBeds bed { get; set; }
        public long HospitalBronRoomsid { get; set; }
        public HospitalBronRooms room { get; set; }

    }
}
