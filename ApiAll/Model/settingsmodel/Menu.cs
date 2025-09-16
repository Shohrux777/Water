using System;
namespace ApiAll.Model.settingsmodel
{
    public class Menu : BaseModel
    {
        public String Name { get; set; }
        public String Value { get; set; }
        public String LinkStr { get; set; }
        public String IconStr{get;set;}
    }
}
