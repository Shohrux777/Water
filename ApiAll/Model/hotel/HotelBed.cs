using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.hotel
{
    [Table("hotel_beds")]
    public class HotelBed:HotelBaseModel
    {
        public String name { get; set; }
        public double price { get; set; }
    }
}
