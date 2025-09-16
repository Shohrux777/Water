using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_product_type")]
    public class PosProductType : PosBaseModel
    {
        public String name { get; set; }
    }
}
