using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_company")]
    public class OquvMarkazCompany:OquvMarkazBaseModel
    {
        public String name { get; set; }
    }
}
