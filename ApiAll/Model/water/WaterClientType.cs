using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    [Table("water_client_type")]
    public class WaterClientType : WaterBaseModel
    {
        public String name { get; set; }
        public String info { get; set; }
        public bool type_info { get; set; } = false;

        
    }
}
