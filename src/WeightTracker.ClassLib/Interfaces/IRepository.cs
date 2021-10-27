using System.Collections.Generic;
using WeightTracker.ClassLib.Models;


namespace WeightTracker.ClassLib.Interfaces
{
    public interface IRepository
    {
        bool Insert(WeightRecord weightRecord);
        WeightRecord GetRecordById(int Id);
        bool Update (WeightRecord weightRecord);
        List<WeightRecord> GetAll(bool ascending);
        bool Delete(int id);

    }
}