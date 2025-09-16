using System;
namespace ApiAll.Model.tekistil
{
    public class TexProductAndXarakteristika : TekstilBaseModel
    {
        public TexProduct product { get; set; }
        public long TexProductid { get; set; }
        public TexXarakteristika xarakteristika { get; set; }
        public long TexXarakteristikaid { get; set; }
    }
}
