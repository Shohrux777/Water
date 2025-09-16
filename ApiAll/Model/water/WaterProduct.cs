using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    [Table("water_product")]
    public class WaterProduct : WaterBaseModel
    {
        public String name { get; set; }
        public String info { get; set; }
        public String code { get; set; }
        public String note { get; set; }
        public bool main_product { get; set; } = false;
    }
}
