using WeightTracker.ClassLib.Interfaces;
using WeightTracker.ClassLib.Models;

namespace WeightTracker.ClassLib.Rules
{
    public class IdWeightRecordRule : IWeightRecordRule
    {
        public bool IsValid(WeightRecord weightRecord)
        {
            return !(weightRecord.Id == 0);
        }
    }
}