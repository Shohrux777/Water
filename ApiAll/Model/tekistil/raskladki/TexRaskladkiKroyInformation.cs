using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApiAll.Model.tekistil.raskladki
{
    [Table("tex_raskladki_model_kroy_information")]
    public class TexRaskladkiKroyInformation : TekstilBaseModel
    {
        
        public String name1 { get; set; }
        public double qty1 { get; set; } = 0.0;

        public String name2 { get; set; }
        public double qty2 { get; set; } = 0.0;

        public String name3 { get; set; }
        public double qty3 { get; set; } = 0.0;


        public String name4 { get; set; }
        public double qty4 { get; set; } = 0.0;

        public String name5 { get; set; }
        public double qty5 { get; set; } = 0.0;

        public String name6 { get; set; }
        public double qty6 { get; set; } = 0.0;

        public String name7 { get; set; }
        public double qty7 { get; set; } = 0.0;

    }
}
