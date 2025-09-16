using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_order_item_steps")]
    public class TexOrderItemSteps : TekstilBaseModel
    {
        public String name { get; set; }
        public bool cutting { get; set; } = false;
        public bool finish { get; set; } = false;

        public String window_name { get; set; }
    }
}
