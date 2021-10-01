using WeightTracker.ClassLib.Interfaces;
using WeightTracker.ClassLib.Models;

namespace WeightTracker.ClassLib.Rules
{
    public class PercentRangeWeightRecordRule : IWeightRecordRule
    {
        public bool IsValid(WeightRecord weightRecord)
        {
            return IsInRange(weightRecord.BodyFatPercent) &&
            IsInRange(weightRecord.BonesPercent) &&
            IsInRange(weightRecord.WaterPercent);
        }

        private bool IsInRange(double value)
        {
            return value > 0.0 && value < 100.0;
        }
    }
}