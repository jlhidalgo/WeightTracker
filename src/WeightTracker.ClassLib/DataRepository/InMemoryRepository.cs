using System.Collections.Generic;
using System.Linq;
using WeightTracker.ClassLib.Interfaces;
using WeightTracker.ClassLib.Models;
using WeightTracker.ClassLib.Rules;

namespace WeightTracker.ClassLib.DataRepository
{
    public class InMemoryRepository : IRepository
    {
        private Dictionary<int, WeightRecord> _weightRecords = new Dictionary<int, WeightRecord>();
        private List<IWeightRecordRule> _weightRecordRules = new List<IWeightRecordRule>();
        public InMemoryRepository()
        {
            _weightRecordRules.Add(new IdWeightRecordRule());
            _weightRecordRules.Add(new PercentRangeWeightRecordRule());
            _weightRecordRules.Add(new PercentSumWeightRecordRule());
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
            if (weightRecord == null || 
                !_weightRecordRules.All(rule => rule.IsValid(weightRecord)) ||
                _weightRecords.ContainsKey(weightRecord.Id))
                {
                    return false;
                }

            _weightRecords.Add(weightRecord.Id, weightRecord);
            return true;
        }

        //Implement a filter to apply multiple rules
        // perhaps the rules can be implemented using a different technique
        //Implement a mapper from weight record to a list of doubles
        // Implement a helper that validate percentages
        public bool Update(WeightRecord weightRecord)
        {
            throw new System.NotImplementedException();
        }
    }
}