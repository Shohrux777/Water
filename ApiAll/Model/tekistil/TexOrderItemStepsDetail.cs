using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_order_item_steps_detail")]
    public class TexOrderItemStepsDetail:TekstilBaseModel
    {
        public long order_item_steps_id { get; set; }


        public long? main_order_item_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("main_order_item_id")]
        public TexOrderItem mainOrderItem { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("order_item_steps_id")]
        public TexOrderItemSteps orderItemSteps { get; set; }
        public long order_item_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("order_item_id")]
        public TexOrderItem orderItem { get; set; }

        public long? for_private_auth_id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        [ForeignKey("for_private_auth_id")]
        public TexAuthorization authorization { get; set; }
        public int sort_number { get; set; }
        public bool start { get; set; } = false;
        public bool stop { get; set; } = false;
        public long timer_in_minuts { get; set; }
        public DateTime start_time { get; set; } = DateTime.Now;
        public DateTime stop_time { get; set; } = DateTime.Now;
        public DateTime begin_date_time { get; set; } = DateTime.Now;
    }
}
