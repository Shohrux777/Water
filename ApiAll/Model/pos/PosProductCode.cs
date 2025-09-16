using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_product_code")]
    public class PosProductCode : PosBaseModel
    {
        public String barcode { get; set; }
        public long product_id { get; set; }

        [ForeignKey("product_id")]
        public PosProduct product { get; set; }
    }
}
