using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_rasxod_list")]
    public class OquvMarkazOstatkaRasxodInfo : OquvMarkazBaseModel
    {
        public String note { get; set; }
        public double qty { get; set; }
        public long OquvMarkazUserid { get; set; }
        public OquvMarkazUser user { get; set; }
        public long OquvMarkazProductid { get; set; }
        public OquvMarkazProduct product { get; set; }

        [NotMapped]
        public String product_name => product != null ? product.name : "";
        [NotMapped]
        public String user_name => user != null ? user.fio : "";
    }
}
