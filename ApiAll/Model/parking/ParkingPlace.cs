using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.parking
{
    [Table("parking_places")]
    public class ParkingPlace : ParkingBase
    {
        public String name { get; set; }
        public String address { get; set; }
        public String note { get; set; }
        public long uniq_code { get; set; }
        public double lat { get; set; }
        public double log{ get; set; }
        public double phone_payment { get; set; }
        public long card_count { get; set; }
        public double limit_cost { get; set; }
        public double places_count { get; set; }
        public String phone_number { get; set; }
        
    }
}
