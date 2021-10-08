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
            return _weightRecords.Remove(id);
        }

        public List<WeightRecord> GetAll(bool ascending = true)
        {
            var records = _weightRecords.Values.ToList();
                
            if(ascending)
                return records.OrderBy(x => x.CreatedDate).ToList();
            else
                return records.OrderByDescending(x => x.CreatedDate).ToList();
            
        }

        // todo: add logs
        public bool Insert(WeightRecord weightRecord)
        {
            if (!_weightRecordRules.All(rule => rule.IsValid(weightRecord)) ||
                _weightRecords.ContainsKey(weightRecord.Id))
                {
                    return false;
                }

            _weightRecords.Add(weightRecord.Id, weightRecord);
            return true;
        }

        public bool Update(WeightRecord weightRecord)
        {
            throw new System.NotImplementedException();
        }
    }
}