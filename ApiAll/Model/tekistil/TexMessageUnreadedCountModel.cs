using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    public class TexMessageUnreadedCountModel
    {
        public long count { get; set; }
        public long friend_auth_id { get; set; }
        public long owner_auth_id { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public TexAuthorization authorization { get; set; }
    }
}
