using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeightTracker.ClassLib.DataRepository;
using WeightTracker.ClassLib.Models;

namespace WeightTracker.ClassLib.Tests.DataRepository
{
    [TestClass]
    public class InMemoryRepositoryTests
    {
        private WeightRecord _weightRecordOK;

        [TestInitialize]
        public void Setup()
        {
            _weightRecordOK = new WeightRecord { Id = 1,
            CreatedDate = DateTime.Now, 
            BodyFatPercent = 1,
            BonesPercent = 1,
            WaterPercent = 1
            };
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
            var result = sut.Insert(null);
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void ShouldNotInsertRecordIfIdIsZero(){
            var sut = new InMemoryRepository();
            var result = sut.Insert(new WeightRecord());
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow(0,1,1)]
        [DataRow(1,0,1)]
        [DataRow(1,1,0)]
        public void ShouldNotInsertRecordIfAnyPercentIsZero(double bfp, double bp, double wp){
            var wr = new WeightRecord { Id = 1,
            CreatedDate = DateTime.Now, 
            BodyFatPercent = bfp,
            BonesPercent = bp,
            WaterPercent = wp
            };
            var sut = new InMemoryRepository();
            var result = sut.Insert(wr);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow(100,1,1)]
        [DataRow(1,100,1)]
        [DataRow(1,1,100)]
        public void ShouldNotInsertRecordIfAnyPercentIsGreaterThan100(double bfp, double bp, double wp){
            var wr = new WeightRecord { Id = 1,
            CreatedDate = DateTime.Now, 
            BodyFatPercent = bfp,
            BonesPercent = bp,
            WaterPercent = wp
            };
            var sut = new InMemoryRepository();
            var result = sut.Insert(wr);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow(50,50,9)]
        [DataRow(98,1,1)]
        [DataRow(40,40,20)]
        public void ShouldNotInsertRecordIfPercentsSumIsGreaterThan99(double bfp, double bp, double wp){
            var wr = new WeightRecord { Id = 1,
            CreatedDate = DateTime.Now, 
            BodyFatPercent = bfp,
            BonesPercent = bp,
            WaterPercent = wp
            };
            var sut = new InMemoryRepository();
            var result = sut.Insert(wr);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldInsertRecordIfObjectOk(){
            var sut = new InMemoryRepository();
            var result = sut.Insert(_weightRecordOK);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShouldNotInsertIfIdAlreadyInserted(){
            var sut = new InMemoryRepository();
            var result = sut.Insert(_weightRecordOK);
            result = sut.Insert(_weightRecordOK);
            Assert.AreEqual(false, result);
        }
    }
}