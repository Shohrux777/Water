using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil.seworder
{
    [Table("tex_sew_order_item")]
    public class TexSewOrderItem : TekstilBaseModel
    {
        public long TexSewOrderid { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public TexSewOrder order { get; set; }

        public long TexProductid{ get; set; }
        public TexProduct product { get; set; }

        public long? TexColorid { get; set; }
        public TexColor color { get; set; }

        public double qty { get; set; } = 0.0;

        public double real_qty { get; set; } = 0.0;

        public double brak_qty { get; set; } = 0.0;
        public String note { get; set; }

        public String image_url { get; set; }

        public String image_base_64 { get; set; }

        public long? TexSizeid { get; set; }
        public TexSize size { get; set; }

        public double reserved_qty { get; set; } = 0.0;

        
        public List<TexSewOrderItemStep> itemStep { get; set; }


    }
}
