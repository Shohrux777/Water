using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    [Table("water_contragent_product")]
    public class WaterContragentProduct : WaterBaseModel
    {
        public String name { get; set; }
        public String model_name { get; set; }
        public double price { get; set; } = 0.0;
        public double real_price { get; set; } = 0.0;
        public double persantage { get; set; } = 0.0;
        public double profit { get; set; } = 0.0;
        public String image_str { get; set; }
        public String image_url { get; set; }
        public bool not_left { get; set; } = false;
        public WaterContragent contragent { get; set; }
        public long? WaterContragentid { get; set; }



    }
}
