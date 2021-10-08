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
        private WeightRecord _weightRecordOK2;
        private WeightRecord _weightRecordOK3;

        [TestInitialize]
        public void Setup()
        {
            _weightRecordOK = new WeightRecord { Id = 1,
                CreatedDate = DateTime.Now.AddDays(1), 
                BodyFatPercent = 1,
                BonesPercent = 1,
                WaterPercent = 1
            };

            _weightRecordOK2 = new WeightRecord { Id = 2,
                CreatedDate = DateTime.Now.AddDays(-1), 
                BodyFatPercent = 50,
                BonesPercent = 30,
                WaterPercent = 10
            };

            _weightRecordOK3 = new WeightRecord { Id = 3,
                CreatedDate = DateTime.Now.AddDays(0), 
                BodyFatPercent = 50,
                BonesPercent = 30,
                WaterPercent = 10
            };
        }

        #region GetAll Tests

        [TestMethod]
        public void ShouldReturnEmptyListIfNoRecords(){
            var sut = new InMemoryRepository();
            var result = sut.GetAll(true);
            Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void ShouldReturnListWithAllRecords(){
            var sut = new InMemoryRepository();
            sut.Insert(_weightRecordOK);
            sut.Insert(_weightRecordOK2);

            var result = sut.GetAll(true);
            Assert.AreEqual(result.Count, 2);
        }

        [TestMethod]
        public void ShouldPersistRecordsDataWhenConvertedToList(){
            var sut = new InMemoryRepository();
            sut.Insert(_weightRecordOK);
            sut.Insert(_weightRecordOK2);

            var result = sut.GetAll(true);
            Assert.AreNotEqual(-1, result.IndexOf(_weightRecordOK));
            Assert.AreNotEqual(-1, result.IndexOf(_weightRecordOK2));
            
        }

        [TestMethod]
        public void ShouldReturnRecordsInAscendingOrderByCreatedDate(){
            var sut = new InMemoryRepository();
            sut.Insert(_weightRecordOK);
            sut.Insert(_weightRecordOK2);
            sut.Insert(_weightRecordOK3);

            var result = sut.GetAll(true);
            Assert.AreEqual(2, result.IndexOf(_weightRecordOK));
            Assert.AreEqual(0, result.IndexOf(_weightRecordOK2));
            Assert.AreEqual(1, result.IndexOf(_weightRecordOK3));
            
        }

        [TestMethod]
        public void ShouldReturnRecordsInDescendingOrderByCreatedDate(){
            var sut = new InMemoryRepository();
            sut.Insert(_weightRecordOK);
            sut.Insert(_weightRecordOK2);
            sut.Insert(_weightRecordOK3);

            var result = sut.GetAll(false);
            Assert.AreEqual(0, result.IndexOf(_weightRecordOK));
            Assert.AreEqual(2, result.IndexOf(_weightRecordOK2));
            Assert.AreEqual(1, result.IndexOf(_weightRecordOK3));
            
        }

        #endregion

        #region Delete Tests
             
        #endregion

        #region Update Tests
        [TestMethod]
        public void ShouldNotDeleteAnythingIfRecordsListIsEmpty(){
            var sut = new InMemoryRepository();
            var result = sut.Delete(4);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShouldNotDeleteAnythingIfIdIsNotInRecords(){
            var sut = new InMemoryRepository();
            sut.Insert(_weightRecordOK);
            sut.Insert(_weightRecordOK2);
            var result = sut.Delete(4);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShouldRemoveRecordIfFoundInRecordsList(){
            var sut = new InMemoryRepository();
            sut.Insert(_weightRecordOK);
            sut.Insert(_weightRecordOK2);
            var result = sut.Delete(_weightRecordOK.Id);
            Assert.AreEqual(true, result);
            
            var weightRecords = sut.GetAll();
            Assert.AreEqual(1, weightRecords.Count);
            Assert.AreEqual(_weightRecordOK2.Id, weightRecords[0].Id);
        }
             
        #endregion

        #region Insert Tests
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
        [DataRow(-1, 1, 1)]
        [DataRow(1, -1, 1)]
        [DataRow(1, 1, -1)]
        public void ShouldNotInsertRecordIfAnyPercentIsLessThanZero(double bfp, double bp, double wp){
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
        public void ShouldInsertMultipleRecorsWithDifferentIds(){
            var sut = new InMemoryRepository();
            var result = sut.Insert(_weightRecordOK);
            Assert.AreEqual(true, result);

            result = sut.Insert(_weightRecordOK2);
            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public void ShouldNotInsertIfIdAlreadyInserted(){
            var sut = new InMemoryRepository();
            var result = sut.Insert(_weightRecordOK);
            result = sut.Insert(_weightRecordOK);
            Assert.AreEqual(false, result);
        }
        
        #endregion
    }
}