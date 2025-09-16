using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.analiz
{
    [Table("hospital_koagulogramma")]
    public class HospitalKoagulogramma: HospitalBaseModel
    {
        public String device_name { get; set; }
        public String index_pt { get; set; }
        public String vremya_pt { get; set; }
        public String isi { get; set; }
        public String fib { get; set; }
        public String achtb { get; set; }
        public String tt { get; set; }
        public String diametr { get; set; }
    }
}
