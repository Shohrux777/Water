using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil
{
    [Table("tex_size_type")]
    public class TexSizeType : TekstilBaseModel
    {
        [Required]
        public String name { get; set; }
        public String note { get; set; }
        public List<TexSize> size_iem_list { get; set; }

    }
}
