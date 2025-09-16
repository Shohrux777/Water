using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.analiz
{
    [Table("hospital_peshob")]
    public class HospitalPeshob: HospitalBaseModel
    {
        public String device_name { get; set; }
        public String kolichestva { get; set; }
        public String svet { get; set; }
        public String leykositi { get; set; }
        public String nitriti { get; set; }
        public String urobilinogen { get; set; }
        public String belot { get; set; }
        public String kislotnost { get; set; }
        public String krov { get; set; }
        public String udalleniy_ves { get; set; }
        public String aseton { get; set; }
        public String bilirubin { get; set; }
        public String glyukoza { get; set; }
        public String askorbinnaya_kislota { get; set; }
        public String epitoliy_ploskiy { get; set; }
        public String epitoliy_pochechniy { get; set; }
        public String epiteliy_promujechotniy { get; set; }
        public String leykositi2 { get; set; }
        public String eritoriseti_ne_izminenne { get; set; }
        public String silindri_geolinoviy { get; set; }
        public String silindri_zernosti { get; set; }
        public String silindri_voskovidniy { get; set; }
        public String sliz { get; set; }
        public String bakteri { get; set; }
        public String soli { get; set; }
        public String prozrachnost { get; set; }
        public String eritoriseti_izminenne { get; set; }
    }
}
