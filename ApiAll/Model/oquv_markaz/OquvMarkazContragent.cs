using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_contragent")]
    public class OquvMarkazContragent : OquvMarkazBaseModel
    {
        public String name { get; set; }
        public String note { get; set; }
        public String icon_base_64_str { get; set; }
    }
}
