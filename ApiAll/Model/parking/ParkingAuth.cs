using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.parking
{
    [Table("parking_auth")]
    public class ParkingAuth : ParkingBase
    {
        public String login { get; set; }
        public String password { get; set; }
        public ParkingUsers users { get; set; }
        public long ParkingUsersid { get; set; }
        public List<long> parking_ids { get; set; }
    }
}
