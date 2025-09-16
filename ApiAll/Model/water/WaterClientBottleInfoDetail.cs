using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    [Table("water_client_bottle_info_detail")]
    public class WaterClientBottleInfoDetail : WaterBaseModel
    {
         public WaterClientBottleInfo clientBottleInfo { get; set; }
         public long WaterClientBottleInfoid { get; set; }
         public long bottle_count { get; set; } = 0;
         public long bottle_count_real { get; set; } = 0;
         public long bottle_count_get { get; set; } = 0;
         public bool get_or_give { get; set; } = false;
         public DateTime last_order_item_accepted_date_time { get; set; } = DateTime.Now;
    }
}
