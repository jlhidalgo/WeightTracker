using WeightTracker.ClassLib.Models;

namespace WeightTracker.ClassLib.Interfaces
{
    public interface IWeightRecordRule
    {
         bool IsValid(WeightRecord weightRecord);
    }
}