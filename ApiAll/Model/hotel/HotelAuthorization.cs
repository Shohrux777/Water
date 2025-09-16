using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.hotel
{
    [Table("hotel_authorization")]
    public class HotelAuthorization:HotelBaseModel
    {
        public String login { get; set; }
        public String password { get; set; }
        public int permission_type { get; set; }
        public String name { get; set; }
        public String surname { get; set; }
        public String phone_number { get; set; }
        public String address { get; set; }
        public long? bot_id { get; set; }
    }
}
