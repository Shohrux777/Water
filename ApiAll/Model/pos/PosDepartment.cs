using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_department")]
    public class PosDepartment : PosBaseModel
    {
        public String name { get; set; }
        public long company_id { get; set; }

        [ForeignKey("company_id")]
        public PosCompany company { get; set; }
        public long? main_department_id { get; set; }

        [ForeignKey("main_department_id")]
        public PosDepartment department { get; set; }
    }
}
