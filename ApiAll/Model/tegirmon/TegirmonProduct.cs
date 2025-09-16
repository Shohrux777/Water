using System;
namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_product")]
    public class TegirmonProduct : TegirmonBaseModel
    {
        public String name { get; set; }
        public String print_name { get; set; }
        public String code { get; set; }
        public double price { get; set; } = 0.0;
        public double buyed_price { get; set; } = 0.0;
        public String image_base_64 { get; set; }
        public String image_url { get; set; }
        public String shitrix_code { get; set; }
        public DateTime created_date { get; set; } = DateTime.Now;
        public long TegirmonUnitMeasurmentid { get; set; }
        public TegirmonUnitMeasurment unitMeasurment { get; set; }
        public long? bot_id { get; set; }
    }
}
