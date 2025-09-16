using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.skud
{
    [Table("skud_group_access")]
    public class SkudGroupAccess
    {
        [Key]
        public String group_name { get; set; }
        public String door { get; set; }
        public String acc_level { get; set; }
        public int _index { get; set; }
        public int doorno { get; set; }

    }
}
