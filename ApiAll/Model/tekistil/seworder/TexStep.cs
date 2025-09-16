using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil.seworder
{
    [Table("tex_step")]
    public class TexStep : TekstilBaseModel
    {
        public String name { get; set; }
        public bool finish { get; set; } = false;
        public bool rasxod { get; set; } = false;

    }
}
