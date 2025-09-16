using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.hotel
{
    [System.ComponentModel.DataAnnotations.Schema.Table("hotel_room_type")]
    public class HotelRoomType:HotelBaseModel
    {
        public String name { get; set; }
    }
}
