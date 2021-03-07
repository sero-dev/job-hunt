namespace Domain.Entities
{
    public class Amenity
    {
        public bool IsTemporaryRemote { get; set; }
        public bool IsFullyRemote { get; set; }
        public bool HasAnnualBonus { get; set; }
        public bool Has401Kmatching { get; set; }
        public bool HasHealthInsurance { get; set; }
        public bool HasDentalInsurance { get; set; }
        public bool HasVisionInsurance { get; set; }
        public bool HasPaidTimeOff { get; set; }
        public string Other { get; set; }
    }
}
