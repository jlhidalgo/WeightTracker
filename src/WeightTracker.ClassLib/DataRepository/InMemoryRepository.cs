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

        //TODO: make this method as bool, return true or false 
        public void Insert(WeightRecord weightRecord)
        {
            if (weightRecord == null || weightRecord.Id == 0)
                return;

            // add validation on percentages, they should be greater than 0 but less than 100
            if (weightRecord.BodyFatPercent > 100 || weightRecord.BonesPercent < 0)

            _weightRecords.Add(weightRecord.Id, weightRecord);
        }
    }
}