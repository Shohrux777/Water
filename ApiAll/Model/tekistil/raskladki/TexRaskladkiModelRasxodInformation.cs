using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApiAll.Model.tekistil.raskladki
{
    [Table("tex_raskladki_model_rasxod_information")]
    public class TexRaskladkiModelRasxodInformation : TekstilBaseModel
    {
      
        public long? TexProductid { get; set; }
        public TexProduct product { get; set; }
        public String ispolzvinnoy_measur { get; set; }
        public double ispolzvinnoy { get; set; } = 0.0;

        public String ubitok_measur { get; set; }
        public double ubitok { get; set; } = 0.0;


        public String zatrachen_measur { get; set; }
        public double zatrachen { get; set; } = 0.0;

        public String poverxnost_measur { get; set; }
        public double poverxnost { get; set; } = 0.0;

        public String poverxnost_measur1 { get; set; }
        public double poverxnost1 { get; set; } = 0.0;


        public String poverxnost_measur2 { get; set; }
        public double poverxnost2 { get; set; } = 0.0;

        public String ves_measurment { get; set; }
        public double ves { get; set; } = 0.0;

        public String ves_measurment1 { get; set; }
        public double ves1 { get; set; } = 0.0;

        public String ves_measurment2 { get; set; }
        public double ves2 { get; set; } = 0.0;
    }
}
