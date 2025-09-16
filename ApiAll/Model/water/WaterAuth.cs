using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    [Table("water_auth")]
    public class WaterAuth:WaterBaseModel
    {
        public String password { get; set; }
        public String login { get; set; }
        public int user_type { get; set; } = 0;
        public WaterUser user { get; set; }
        public long WaterUserid { get; set; }
        public int client_type_info { get; set; } = 0;
       
    }
}
