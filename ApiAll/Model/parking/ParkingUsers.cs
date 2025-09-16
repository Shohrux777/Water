using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.parking
{
    [Table("parking_users")]
    public class ParkingUsers:ParkingBase
    {
        public String fio { get; set; }
        public String position { get; set; }
        public String phone_number { get; set; }
        public List<long> parking_places_ids_list { get; set; }
    }
}
