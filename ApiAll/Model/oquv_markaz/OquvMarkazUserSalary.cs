using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_user_salary")]
    public class OquvMarkazUserSalary:OquvMarkazBaseModel
    {
        public long OquvMarkazUserid { get; set; }
        public OquvMarkazUser user { get; set; }
        public double summ { get; set; }
        public double real_summ { get; set; }
        public List<OquvMarkazUserSalaryItem> items { get; set; }
        
    }
}
