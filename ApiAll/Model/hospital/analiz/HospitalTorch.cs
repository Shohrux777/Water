using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.analiz
{
    [Table("hospital_torch")]
    public class HospitalTorch : HospitalBaseModel
    {
        public String device_name { get; set; }
        public String xlomidin { get; set; }
        public String toksoplazma { get; set; }
        public String smb{ get; set; }
        public String vpg { get; set; }
        public String musorplazma { get; set; }
        public String rubbella { get; set; }
        public String ureaplazma { get; set; }
    }
}
