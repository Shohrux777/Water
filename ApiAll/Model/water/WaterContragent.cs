using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    [Table("water_contragent")]
    public class WaterContragent : WaterBaseModel
    {
        public String name { get; set; }
        public String note { get; set; }
        public String phone_number { get; set; }
        public String phone_number_1 { get; set; }
        public String phone_number_2 { get; set; }
        public String phone_number_3 { get; set; }
        public String address { get; set; }
        public String dokon_number { get; set; }
        public WaterContragentType type { get; set; }
        public long WaterContragentTypeid { get; set; }


    }
}
