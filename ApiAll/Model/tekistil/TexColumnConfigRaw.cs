using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_column_config_raw")]
    public class TexColumnConfigRaw
    {
        public String column_name { get; set; }
    }
}
