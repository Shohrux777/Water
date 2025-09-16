using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.analiz
{
    [Table("hospital_mazok")]
    public class HospitalMazok: HospitalBaseModel
    {
        public String device_name { get; set; }
        //vagina
        public String leykositi_vagina { get; set; }
        public String ploskiy_epiteliy_vagina { get; set; }
        public String gonokokki_vagina { get; set; }
        public String trixomonadi_vagina { get; set; }
        public String kluchoviy_kletki_vagina { get; set; }
        public String drojji_vagina { get; set; }
        public String mikroflora_vagina { get; set; }
        public String sliz_vagina { get; set; }

        //serviks
        public String leykositi_serviks { get; set; }
        public String ploskiy_epiteliy_serviks { get; set; }
        public String gonokokki_serviks { get; set; }
        public String trixomonadi_serviks { get; set; }
        public String kluchoviy_kletki_serviks { get; set; }
        public String drojji_serviks { get; set; }
        public String mikroflora_serviks { get; set; }
        public String sliz_serviks { get; set; }

        //uretra
        public String leykositi_uretra { get; set; }
        public String ploskiy_epiteliy_uretra { get; set; }
        public String gonokokki_uretra { get; set; }
        public String trixomonadi_uretra { get; set; }
        public String kluchoviy_kletki_uretra { get; set; }
        public String drojji_uretra { get; set; }
        public String mikroflora_uretra { get; set; }
        public String sliz_uretra { get; set; }
    }
}
