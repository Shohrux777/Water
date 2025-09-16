using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_position")]
    public class OquvMarkazPosition:OquvMarkazBaseModel
    {
        public String name { get; set; }
    }
}
