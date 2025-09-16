using System;
namespace ApiAll.Model
{
    public class DatchikItem: BaseModel
    {
        public long RoomsId { get; set; }
        public Rooms rooms { get; set; }
        public long ColorId { get; set; }
        public Color color { get; set; }
        public long DatchikId { get; set; }
        public Datchik datchik { get; set; }
        public int order { get; set; }
    }
}
