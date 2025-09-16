using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.analiz
{
    [Table("hospital_umumiy_qon_taxlili")]
    public class HospitalUmQonTaxlili:HospitalBaseModel
    {
        public String device_name { get; set; }
        public String leykositi { get; set; }
        public String neytrofili { get; set; }
        public String limfotsi { get; set; }
        public String monofisitsi { get; set; }
        public String eozinofili { get; set; }
        public String bazofili { get; set; }
        public String neytrofili_2 { get; set; }
        public String limfotsi_2 { get; set; }
        public String monofisitsi_2 { get; set; }
        public String eozinofili_2 { get; set; }
        public String bazofili_2 { get; set; }
        public String eritrositi { get; set; }
        public String gemoglabin { get; set; }
        public String gemotokrit { get; set; }
        public String sr_obyom_er { get; set; }
        public String sr_sod_gem_er { get; set; }
        public String sr_kons_gem_er { get; set; }
        public String shir_ras_er_gem { get; set; }
        public String shir_ras_er_po_obyom { get; set; }
        public String trobositi { get; set; }
        public String sredniy_obyom_trombositov { get; set; }
        public String shir_rasm_tromb_po_obyom { get; set; }
        public String trombokrit { get; set; }
        public String aly { get; set; }
        public String lic { get; set; }
        public String aly_2 { get; set; }
        public String lic_2 { get; set; }
        public String skorst_osedaniy_eritrositov { get; set; }
        public String qon_ivish_begin_date_time { get; set; }
        public String qon_ivish_end_date_time { get; set; }
        public String um_item_1 { get; set; }
        public String um_item_2 { get; set; }
        public String um_item_3 { get; set; }
        public String um_item_4 { get; set; }
        public String um_item_5 { get; set; }
        public String um_item_6 { get; set; }
        public String um_item_7 { get; set; }
        public String um_item_8 { get; set; }
        public String um_item_9 { get; set; }
        public String um_item_10 { get; set; }


    }
}
