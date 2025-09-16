using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_oquvchi_gruppaga_tolov")]
    public class OquvMarkazGruppagaTolov : OquvMarkazBaseModel
    {
        public DateTime begin_date { get; set; } = DateTime.Now;
        public DateTime end_date { get; set; } = DateTime.Now;

        public long? OquvMarkazPupilGroupsid { get; set; }
        public OquvMarkazPupilGroups group { get; set; }

        public long? OquvMarkazClientid { get; set; }
        public OquvMarkazClient oquvchi { get; set; }

        public double summ { get; set; } = 0.0;
        public double qarz_summ { get; set; } = 0.0;
        public double discount_summ { get; set; } = 0.0;
        public double real_summ { get; set; } = 0.0;

    }
}
