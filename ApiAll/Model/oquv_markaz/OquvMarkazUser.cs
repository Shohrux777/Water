using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_user")]
    public class OquvMarkazUser:OquvMarkazBaseModel
    {
        public String fio { get; set; }
        public long OquvMarkazDepartmentid { get; set; }
        public OquvMarkazDepartment department { get; set; }
        public long OquvMarkazPositionid { get; set; }
        public OquvMarkazPosition position { get; set; }
        public String note { get; set; }
        public String address { get; set; }
        public String phone_number { get; set; }
        public long? bot_id { get; set; }
    }
}
