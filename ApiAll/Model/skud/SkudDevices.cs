using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.skud
{
    [Table("devices")]
    public class SkudDevices
    {
        public String mac_address { get; set; }
        public String device_name { get; set; }
        [Required]
        public String ip_address { get; set; }
        public String sn { get; set; }
        public String tip { get; set; }
        public String bor { get; set; }
        public String main_door { get; set; } = "Нет";
    }
}
