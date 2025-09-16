using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    [Table("water_user")]
    public class WaterUser:WaterBaseModel
    {
        public String note { get; set; }
        public String fio { get; set; }
        public String phone_number { get; set; }
        public String car_number { get; set; }
        public String telegram_phonenumber { get; set; }
        public long? bot_id { get; set; }
        public String addrress { get; set; }
        public String position { get; set; }
        [NotMapped]
        public WaterAuth auth { get; set; }
        [NotMapped]
        public long? auth_id { get; set; }
    }
}
