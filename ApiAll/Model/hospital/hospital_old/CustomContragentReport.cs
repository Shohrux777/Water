using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class CustomContragentReport
    {
        public String phone { get; set; }
        public String fio { get; set; }
        public DateTime datereg { get; set; }
        public long mrt { get; set; }
        public long mskt { get; set; }
        public double sum { get; set; }
        public String regionName { get; set; }
        public long contragentId { get; set; }
        [NotMapped]
        public double? payedSumm { get; set; }
        [NotMapped]
        public double? creditSumm { get; set; }
        [NotMapped]
        public double? debitSumm { get; set; }

        [NotMapped]
        public bool? finishStatus { get; set; }



    }
}
