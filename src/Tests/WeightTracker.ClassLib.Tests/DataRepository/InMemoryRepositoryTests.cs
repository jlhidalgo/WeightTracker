using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeightTracker.ClassLib.DataRepository;
using WeightTracker.ClassLib.Models;

namespace WeightTracker.ClassLib.Tests.DataRepository
{
    [TestClass]
    public class InMemoryRepositoryTests
    {
        [TestMethod]
        public void ShouldInsertRecord(){
            var sut = new InMemoryRepository();
            sut.Insert(new WeightRecord());
        }
        
    }
}