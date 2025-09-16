using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_product_tag")]
    public class PosProductTag : PosBaseModel
    {
        public String name { get; set; }
    }
}
