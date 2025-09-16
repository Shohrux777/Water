using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil.seworder
{
    [Table("tex_sew_order_item_step")]
    public class TexSewOrderItemStep : TekstilBaseModel
    {
        public long? TexSewOrderItemid { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public TexSewOrderItem sewOrderItem { get; set; }

        public long sort_number { get; set; } = 0;

        public double qty { get; set; } = 0.0;
        public double real_qty { get; set; } = 0.0;
        public double brak_qty { get; set; } = 0.0;

        public bool start_status { get; set; } = false;
        public bool stop_status { get; set; } = false;

        public bool finish_status { get; set; } = false;

        public DateTime? start_date { get; set; }
        public DateTime? finish_date { get; set; }
        public DateTime? stop_date { get; set; }

        public long? TexAuthorization { get; set; }
        public TexAuthorization authorization { get; set; }

        public String note { get; set; }

        public long? TexStepid { get; set; }
        public TexStep step { get; set; }

        public List<TexSewOrderItemStepItem> stepItemList { get; set; }
    }
}
