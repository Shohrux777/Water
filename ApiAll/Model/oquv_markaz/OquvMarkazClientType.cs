using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{

    [Table("oquv_markaz_client_type")]
    public class OquvMarkazClientType : OquvMarkazBaseModel
    {
        public String name { get; set; }
    }
}
