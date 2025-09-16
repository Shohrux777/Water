using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.pos
{
    [Table("pos_costs")]
    public class PosCosts : PosBaseModel
    {
        public String note { get; set; }
        public double summ { get; set; }
        public long PosAuthorizationid { get; set; }
        public PosAuthorization auth { get; set; }
        public bool closed_status { get; set; } = false;
        [NotMapped]
        public String user_name => auth != null ? (auth.user != null ? auth.user.fio:"") : "";
    }
}
