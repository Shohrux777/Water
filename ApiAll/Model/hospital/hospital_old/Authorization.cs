using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ApiAll.Model.market;

namespace ApiAll.Model
{
    public class Authorization : BaseModel
    {
        public String Login { get; set; }
        public String Password { get; set; }
        public long CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company company { get; set; }
        public long UsersId { get; set; }
        public Users users { get; set; }
        public int UserType { get; set; }
        [NotMapped]
        public MarketClientInfo ClientInfo { get; set; }

    }
}
