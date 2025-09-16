using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.hotel
{
    [Table("hotel_room")]
    public class HotelRoom:HotelBaseModel
    {
        public String name { get; set; }
        public long room_type_id { get; set; }

        [ForeignKey("room_type_id")]
        public HotelRoomType roomType { get; set; }
        public double price { get; set; }
        public int beds_count { get; set; }
    }
}
