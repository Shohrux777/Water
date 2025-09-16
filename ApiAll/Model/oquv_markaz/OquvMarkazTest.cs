using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_client_test")]
    public class OquvMarkazTest : OquvMarkazBaseModel
    {
        public String name { get; set; }
        public double min_value { get; set; } = 0.0;
        public double max_value { get; set; } = 0.0;
    }
}
