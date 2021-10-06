using WeightTracker.ClassLib.Interfaces;
using WeightTracker.ClassLib.Models;

namespace WeightTracker.ClassLib.Rules
{
    public class PercentSumWeightRecordRule : IWeightRecordRule
    {
        public bool IsValid(WeightRecord weightRecord)
        {
            return weightRecord.BodyFatPercent + weightRecord.BonesPercent + weightRecord.WaterPercent < 100;
        }
    }
}