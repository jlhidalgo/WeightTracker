namespace WeightTracker.ClassLib.Models
{

    public class WeightRecord
    {
        public int Id { get; set; }
        public datetime CreatedDate { get; set; }
        public double Weight { get; set; }
        public double BodyFatPercent { get; set; }
        public double BonesPercent { get; set; }
        public double WaterPercent { get; set; }
    }    
}
