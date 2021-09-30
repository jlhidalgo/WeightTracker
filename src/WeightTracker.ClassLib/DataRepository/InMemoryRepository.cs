using System.Collections.Generic;
using System.Linq;
using WeightTracker.ClassLib.Interfaces;
using WeightTracker.ClassLib.Models;

namespace WeightTracker.ClassLib.DataRepository
{
    public class InMemoryRepository : IRepository
    {
        private Dictionary<int, WeightRecord> _weightRecords = new Dictionary<int, WeightRecord>();
        public InMemoryRepository()
        {
            
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<WeightRecord> GetAll(bool ascending)
        {
            return _weightRecords.Values.ToList();
        }

        // todo: add logs
        public bool Insert(WeightRecord weightRecord)
        {
            if (weightRecord == null || weightRecord.Id == 0)
                return false;

            if (!ValidPercentages(weightRecord))
                return false;

            if (!ValidPercentSum(weightRecord))
                return false;

            if (_weightRecords.ContainsKey(weightRecord.Id))
                return false;

            _weightRecords.Add(weightRecord.Id, weightRecord);

            return true;
        }

        //Implement a filter to apply multiple rules
        // perhaps the rules can be implemented using a different technique
        //Implement a mapper from weight record to a list of doubles
        // Implement a helper that validate percentages
        private bool ValidPercentages (WeightRecord weightRecord)
        {
            return IsInRange(weightRecord.BodyFatPercent) &&
            IsInRange(weightRecord.BonesPercent) &&
            IsInRange(weightRecord.WaterPercent);
            
        }

        private bool ValidPercentSum(WeightRecord weightRecord){
            return weightRecord.BodyFatPercent + weightRecord.BonesPercent + weightRecord.WaterPercent < 100;
        }

        private bool IsInRange(double value)
        {
            return value > 0.0 && value < 100.0;
        }

        public bool Update(WeightRecord weightRecord)
        {
            throw new System.NotImplementedException();
        }
    }
}