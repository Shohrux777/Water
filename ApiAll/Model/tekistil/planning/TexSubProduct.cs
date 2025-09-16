using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApiAll.Model.tekistil.planning
{
    [Table("tex_sub_product")]
    public class TexSubProduct : TekstilBaseModel
    {
        public String name { get; set; }
        public String note { get; set; }
        public String print_name { get; set; }
     
    }
}
