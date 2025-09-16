using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApiAll.Model.water
{
    [Table("water_order_item")]
    public class WaterOrderItem : WaterBaseModel
    {
        public DateTime info_order_date { get; set; } = DateTime.Now;
        public long give_botlle { get; set; } = 0;
        public long get_botle { get; set; } = 0;
        public String note { get; set; }
        public String info_str { get; set; }
        public double qty { get; set; } = 0.0;
        public double real_qty { get; set; } = 0.0;
        [JsonIgnore]
        [IgnoreDataMember]
        public WaterOrder order { get; set; }
        public long WaterOrderid { get; set; }
        public WaterProduct product { get; set; }
        public long WaterProductid { get; set; }
        public bool order_item_accepted_status { get; set; } = false;
        public bool bonus_or_not { get; set; } = false;
        public long? deleivered_user_auth_id { get; set; }
     


    }
}
