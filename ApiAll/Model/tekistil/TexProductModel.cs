using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil
{
    [Table("tex_product_model")]
    public class TexProductModel : TekstilBaseModel
    {
        public String name { get; set; }
        public String print_name { get; set; }

        
    }
}
