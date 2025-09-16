using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital
{
    [Table("hospital_marker_serive_types_with_number")]
    public class HospitalMarkSeviceTyesWithNumber : HospitalBaseModel
    {
        public String note { get; set; }
        public String group_name { get; set; }
        public List<long> payments_list { get; set; }
        public List<long> serviece_types { get; set; }
        public String number_str { get; set; }
        public bool finish_all_chekings { get; set; } = false;
        public String url_str { get; set; }

        [NotMapped]
        public List<Payments> payments_list_fake { get; set; }
        [NotMapped]
        public List<ServiceType> serviece_types_fake { get; set; }
    }
}
