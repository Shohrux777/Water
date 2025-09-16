using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class ReturnMoney : BaseModel
    {
        public String Reason { get; set; }
        public long price { get; set; }
        public DateTime RegistratedDate { get; set; }
        public long UsersId { get; set; }
        public Users user { get; set; }
        public Authorization Authorization { get; set; }
        public long AuthorizationId { get; set; }

    }
}
