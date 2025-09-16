using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;

namespace ApiAll.Model.water
{
    [Table("water_client_phone_number")]
    public class WaterClientPhoneNumber : WaterBaseModel
    {
        public String phone_number { get; set; }
        public String note { get; set; }

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
