using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_size")]
    public class TexSize:TekstilBaseModel
    {
        [Required]
        public String name { get; set; }
        public String note { get; set; }
        public double value { get; set; } = 0.0;

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public TexSizeType sizeType { get; set; }
        public long? TexSizeTypeid { get; set; }


    }
}
