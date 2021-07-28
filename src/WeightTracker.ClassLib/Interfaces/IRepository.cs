using System.Collections.Generic;
using WeightTracker.ClassLib.Models;


namespace WeightTracker.ClassLib.Interfaces
{
    public interface IRepository
    {
        void Insert(WeightRecord weightRecord);
        List<WeightRecord> GetAll(bool ascending);
        bool Delete(int id);

    }
}