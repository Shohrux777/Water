using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.pos
{
    [Table("pos_manifacturer")]
    public class PosManifacturer : PosBaseModel
    {
        [Required]
        public String name { get; set; }
        
    }
}
