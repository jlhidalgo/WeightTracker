using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeightTracker.ClassLib.Rules;

namespace WeightTracker.ClassLib.Tests.Rules
{
    [TestClass]
    public class PercentRangeWeightRecordRuleTests
    {
        [TestMethod]
        [DataRow(1.0, 1.0, 0.0)]
        [DataRow(0.0, 1.0, 1.0)]
        [DataRow(1.0, 0.0, 1.0)]
        public void ShouldReturnFalseIfAnyValueIsZero(double bf, double b, double w){
            var sut = new PercentRangeWeightRecordRule();
            var result = sut.IsValid(new Models.WeightRecord{
                BodyFatPercent = bf, 
                BonesPercent=b, 
                WaterPercent=w
                });
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        [DataRow(100.0, 1.0, 99.0)]
        [DataRow(99.0, 100.0, 1.0)]
        [DataRow(1.0, 99.0, 100.0)]
        public void ShouldReturnFalseIfAnyValueIsGreaterThan99(double bf, double b, double w){
            var sut = new PercentRangeWeightRecordRule();
            var result = sut.IsValid(new Models.WeightRecord{
                BodyFatPercent = bf, 
                BonesPercent=b, 
                WaterPercent=w
                });
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        [DataRow(-1.0, 1.0, 99.0)]
        [DataRow(99.0, -1.0, 1.0)]
        [DataRow(1.0, 99.0, -1.0)]
        public void ShouldReturnFalseIfAnyValueIsLessThanZero(double bf, double b, double w){
            var sut = new PercentRangeWeightRecordRule();
            var result = sut.IsValid(new Models.WeightRecord{
                BodyFatPercent = bf, 
                BonesPercent=b, 
                WaterPercent=w
                });
            Assert.AreEqual(false, result);
        }
        
        [TestMethod]
        [DataRow(0.1, 1.0, 99.99)]
        [DataRow(99.99, 0.01, 1.0)]
        [DataRow(1.0, 99.09, 0.009)]
        public void ShouldReturnTrueIfAllValuesAreBetween0And100(double bf, double b, double w){
            var sut = new PercentRangeWeightRecordRule();
            var result = sut.IsValid(new Models.WeightRecord{
                BodyFatPercent = bf, 
                BonesPercent=b, 
                WaterPercent=w
                });
            Assert.AreEqual(true, result);
        }
    }
}