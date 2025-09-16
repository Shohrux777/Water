using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_product")]
    public class OquvMarkazProduct:OquvMarkazBaseModel
    {
        public String name { get; set; }
        public double price { get; set; } = 0.0;

    }
}
