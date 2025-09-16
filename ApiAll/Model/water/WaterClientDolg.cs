using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    [Table("water_client_dolg")]
    public class WaterClientDolg : WaterBaseModel
    {
        public WaterClient client { get; set; }
        public long WaterClientid { get; set; }
        public double summ { get; set; }
        public double real_summ { get; set; }
    }
}
