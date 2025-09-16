using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital
{
    [Table("hospital_analiz_number_mark")]
    public class HospitalAnalizNumberMark : HospitalBaseModel
    {
        public long ServiceTypeId  { get; set; }
        public ServiceType service { get; set; }

        public long PaymentsId  { get; set; }
        public Payments payments { get; set; }

        public bool finish_analiz { get; set; } = false;
        public String link_str { get; set; }

        public DateTime date_time { get; set; } = DateTime.Now;
    }
}
