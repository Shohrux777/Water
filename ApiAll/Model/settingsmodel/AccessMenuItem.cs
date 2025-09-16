using System;
namespace ApiAll.Model.settingsmodel
{
    public class AccessMenuItem : BaseModel
    {
        public long AccessMenuId { get; set; }
        public AccessMenu accessMenu { get; set; }
        public long MenuItemId {get;set;}
        public MenuItem menuItem { get; set; }
        public long AuthorizationId { get; set; }
        public Authorization authorization { get; set; }
    }
}
