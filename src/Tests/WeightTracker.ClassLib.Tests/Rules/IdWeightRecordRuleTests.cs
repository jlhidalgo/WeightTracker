using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeightTracker.ClassLib.Models;
using WeightTracker.ClassLib.Rules;

namespace WeightTracker.ClassLib.Tests.Rules
{
    [TestClass]
    public class IdWeightRecordRuleTests
    {
        [TestMethod]
        public void ShouldReturnFalseIfIdIsZero(){
            var sut = new IdWeightRecordRule();
            var result = sut.IsValid(new WeightRecord());
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShouldReturnTrueIfIdIsGreaterThanZero(){
            var sut = new IdWeightRecordRule();
            var result = sut.IsValid(new WeightRecord{Id = 1});
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ShouldReturnFalseIfIdIsLessThanZero(){
            var sut = new IdWeightRecordRule();
            var result = sut.IsValid(new WeightRecord{Id = -1});
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShouldReturnFalseIfRecordIsNull(){
            var sut = new IdWeightRecordRule();
            WeightRecord weightRecord = null;
            var result = sut.IsValid(weightRecord);
            Assert.AreEqual(false, result);
        }
    }
}