using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    [Table("water_check")]
    public class WaterCheck:WaterBaseModel
    {
        public double summ { get; set; } = 0.0;
        public double bonus { get; set; } = 0.0;
        public double credit { get; set; } = 0.0;
        public double debit { get; set; } = 0.0;
        public double cash { get; set; } = 0.0;
        public double card { get; set; } = 0.0;
        public double online { get; set; } = 0.0;
        public double salary { get; set; } = 0.0;
        public double rasxod { get; set; } = 0.0;
        public double discount { get; set; } = 0.0;
        public double discount_pesantage { get; set; } = 0.0;
        public double discount_summ { get; set; } = 0.0;
        public String note { get; set; }
        public String user_name { get; set; }
        public String reserve { get; set; }
        public double bonus_summ { get; set; } = 0.0;
        public double cashback_summ { get; set; } = 0.0;
        public String cashback_card { get; set; }
        public String cashback_user_phone_number { get; set; }
        public String cassir_name { get; set; }
        public bool kassa_close_status { get; set; } = false;
        public double kam_chiqqan_summ { get; set; } = 0.0;
        public WaterAuth auth { get; set; }
        public long? WaterAuthid { get; set; }
        [NotMapped]
        public String product_name_list_pp { get; set; }
        [NotMapped]
        public String product_name_list_pp_1 { get; set; }
        [NotMapped]
        public String product_name_list_pp_2 { get; set; }

    }
}
