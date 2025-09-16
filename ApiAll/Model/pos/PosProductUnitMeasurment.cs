using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_product_unitmeasurment")]
    public class PosProductUnitMeasurment : PosBaseModel
    {
        public String name { get; set; }
    }
}
