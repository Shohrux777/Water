using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_brend")]
    public class PosBrend: PosBaseModel
    {
        public String name { get; set; }
    }
}
