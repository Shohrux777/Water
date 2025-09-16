using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    [Table("tex_device_sub_proccess_detail")]
    public class TexDeviceSubProccessDetail:TekstilBaseModel
    {
        public long TexSubProccessid  { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public TexSubProccess subProccess { get; set; }

        public long TexDeviceid { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public TexDevice texDevice { get; set; }
    }
}
