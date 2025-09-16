using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.analiz
{
    [Table("hospital_qondagi_garmonlar")]
    public class HospitalQondagiGarmonlar:HospitalBaseModel
    {
        public String device_name { get; set; }
        public String ttg { get; set; }
        public String t_4 { get; set; }
        public String t_4_svabodno { get; set; }
        public String testosteron { get; set; }
        public String estradiol { get; set; }
        public String prolaktin { get; set; }
        public String fcg { get; set; }
        public String lg { get; set; }
        public String progesteron { get; set; }
        public String deac { get; set; }
        public String obshiy_t3 { get; set; }
        public String svabodniy_t3 { get; set; }
    }
}
