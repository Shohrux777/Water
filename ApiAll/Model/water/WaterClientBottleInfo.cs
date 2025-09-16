using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    [Table("water_client_bottle_info")]
    public class WaterClientBottleInfo:WaterBaseModel
    {
        public double bottle_count { get; set; } = 0;
        public double bottle_count_real { get; set; } = 0;

        public long WaterClientid { get; set; }
        public WaterClient client { get; set; }

        public WaterClientAddress address { get; set; }
        public long WaterClientAddressid { get; set; }
        public List<WaterClientBottleInfoDetail> info_detail { get; set; }

        public WaterProduct product { get; set; }
        public long WaterProductid { get; set; }
    }
}
