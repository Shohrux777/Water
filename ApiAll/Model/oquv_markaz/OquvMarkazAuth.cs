using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_authorization")]
    public class OquvMarkazAuth: OquvMarkazBaseModel
    {
        public String login { get; set; }
        public String password { get; set; }
        public int user_type { get; set; } = 0;
        public long OquvMarkazUserid { get; set; }
        public OquvMarkazUser user { get; set; }
    }
}
