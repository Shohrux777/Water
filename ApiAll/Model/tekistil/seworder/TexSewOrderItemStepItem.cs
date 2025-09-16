using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil.seworder
{
    [Table("tex_sew_order_item_step_item")]
    public class TexSewOrderItemStepItem : TekstilBaseModel
    {
        public long TexSewOrderItemStepid { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public TexSewOrderItemStep orderItemStep { get; set; }

        public long TexAuthorizationid { get; set; }
        public TexAuthorization authorization { get; set; }

        public double qty { get; set; } = 0.0;

        public double real_qty { get; set; } = 0.0;

        public double brak_qty { get; set; } = 0.0;

        public bool brak { get; set; } = false;

        public String note { get; set; }

    }
}
