using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_salary_item")]
    public class OquvMarkazUserSalaryItem : OquvMarkazBaseModel
    {
        public double summ { get; set; } = 0.0;

        public long OquvMarkazUserSalaryid{ get; set; }
        public OquvMarkazUserSalary salary { get; set; }

        public DateTime date_time { get; set; } = DateTime.Now;

        public long OquvMarkazClientid { get; set; }
        public OquvMarkazClient oquvchi { get; set; }

        public long OquvMarkazPupilGroupsid { get; set; }
        public OquvMarkazPupilGroups group { get; set; }


    }
}
