using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil.planning
{
    [Table("tex_product_and_sub_detail")]
    public class TexProductAndSubDetail : TekstilBaseModel
    {
        

        public long? TexProductid { get; set; }
        public TexProduct texProduct { get; set; }

        public long? TexSubProductid { get; set; }

        public TexSubProduct texSubProduct { get; set; }

    }
}
