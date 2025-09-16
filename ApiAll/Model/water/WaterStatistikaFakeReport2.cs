using System;
namespace ApiAll.Model.water
{
    public class WaterStatistikaFakeReport2
    {
        public String fio { get; set; } = "";
        public String address { get; set; } = "";
        public String tuman_name { get; set; } = "";
        public String last_order_date { get; set; } = "";
        public String first_order_date { get; set; } = "";
        public double? olgan_suv_soni { get; set; } = 0;
        public double? bakalashka_soni1 { get; set; } = 0;
        public long? zakazlar_soni { get; set; } = 0;
    }
}
