using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;

namespace ApiAll.Model.water
{
    [Table("water_client_address")]
    public class WaterClientAddress: WaterBaseModel
    {
        public String phone_number { get; set; }
        public String phone_number_1 { get; set; }
        public String phone_number_2 { get; set; }
        public String address { get; set; }
        public String note_1 { get; set; }
        public String note_2 { get; set; }
        public double longutidue { get; set; } = 0.0;
        public double latitude { get; set; } = 0.0;
        public double latidu { get; set; } = 0.0;
        public double longitu { get; set; } = 0.0;
        public String home_code { get; set; }
        public String padez { get; set; }
        public String home_number { get; set; }
        public WaterTuman tuman { get; set; }
        public long WaterTumanid { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public WaterClient client { get; set; }
        public long WaterClientid { get; set; }
        [NotMapped]
        public String client_name_str => client != null ? client.fio : "";
        [NotMapped]
        public JObject clinet_obj { get; set; }
    }
}
