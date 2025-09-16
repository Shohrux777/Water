using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_sub_department")]
    public class PosSubDepartment : PosBaseModel
    {
        public String name { get; set; }
        public long department_id { get; set; }

        [ForeignKey("department_id")]
        public PosDepartment department { get; set; }
    }
}
