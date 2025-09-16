using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.skud
{
    [Table("skud_faces")]
    public class SkudFaces
    {
        public String ip { get; set; }
        public String nomi { get; set; }
    }
}
