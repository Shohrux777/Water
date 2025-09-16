using System;
namespace ApiAll.Model.settingsmodel
{
    public class AccessMenu : BaseModel
    {
        public long MenuId { get; set; }
        public Menu menu { get; set; }
        public long AuthorizationId  { get; set; }
        public Authorization authorization{get;set;}

    }
}
