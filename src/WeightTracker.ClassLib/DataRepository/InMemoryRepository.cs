using System.Collections.Generic;
using WeightTracker.ClassLib.Interfaces;
using WeightTracker.ClassLib.Models;

namespace WeightTracker.ClassLib.DataRepository
{
    public class InMemoryRepository : IRepository
    {
        public InMemoryRepository()
        {
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<WeightRecord> GetAll(bool ascending)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(WeightRecord weightRecord)
        {
            throw new System.NotImplementedException();
        }
    }
}