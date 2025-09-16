using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    [Table("pos_authorization")]
    public class PosAuthorization : PosBaseModel
    {
        public long company_id { get; set; }

        [ForeignKey("company_id")]
        public PosCompany company { get; set; }
        public long user_id { get; set; }
        [ForeignKey("user_id")]
        public PosUser user { get; set; }
        [NotMapped]
        public String user_name => user != null ? user.fio : "";
        [NotMapped]
        public String company_name => company != null ? company.name : "";
        public String login { get; set; }
        public String password { get; set; }
        public String password_not_md5 { get; set; }
        public int access_type { get; set; }

    }
}
