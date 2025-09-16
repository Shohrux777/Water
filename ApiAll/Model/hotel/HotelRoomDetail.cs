using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.hotel
{
    [Table("hotel_room_detail")]
    public class HotelRoomDetail:HotelBaseModel
    {
        public long room_id { get; set; }

        [ForeignKey("room_id")]
        public HotelRoom room { get; set; }
        public long bed_id { get; set; }

        [ForeignKey("bed_id")]
        public HotelBed bed { get; set; }
    }
}
