using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    public class TexPaginationModel
    {
        public int items_count { get; set; }
        public int current_page { get; set; }
        public int current_item_count { get; set; }
        public JArray items_list { get; set; }
    }
}
