namespace ApiAll.Model.hospital.bron_new
{
    public class HospitalRoomType : HospitalBaseStandartModel
    {
        public string name { get; set; }
        public double room_price{ get; set; } = 0.0;
        public double room_bed_price { get; set; } = 0.0;
        public double room_bed_price_not_patient { get; set; } = 0.0;
    }
}
