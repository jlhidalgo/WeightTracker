using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeightTracker.ClassLib.DataRepository;
using WeightTracker.ClassLib.Models;

namespace WeightTracker.ClassLib.Tests.DataRepository
{
    [TestClass]
    public class InMemoryRepositoryTests
    {
        [TestInitialize]
        public void Setup()
        {
            
        }

        [TestMethod]
        public void ShouldReturnEmptyDictionaryIfNoRecords(){
            var sut = new InMemoryRepository();
            var result = sut.GetAll(true);
            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void ShouldNotInsertRecordIfNullObject(){
            var sut = new InMemoryRepository();
            sut.Insert(null);
            var result = sut.GetAll(true);
            Assert.AreEqual(result.Count, 0);
        }
        
        [TestMethod]
        public void ShouldNotInsertRecordIfIdIsZero(){
            var sut = new InMemoryRepository();
            sut.Insert(new WeightRecord());
            var result = sut.GetAll(true);
            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void ShouldInsertRecordIfObjectOk(){
            var sut = new InMemoryRepository();
            sut.Insert(new WeightRecord { Id = 1, CreatedDate = DateTime.Now });
            var result = sut.GetAll(true);
            Assert.AreEqual(result.Count, 1);
        }
    }
}