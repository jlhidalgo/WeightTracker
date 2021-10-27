using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeightTracker.ClassLib.Models;
using WeightTracker.ClassLib.Rules;

namespace WeightTracker.ClassLib.Tests.Rules
{
    [TestClass]
    public class PercentSumWeightRecordRuleTests
    {
        [TestMethod]
        [DataRow(99.0, 1.0, 1.0)]
        [DataRow(50.0, 50.0, 50.0)]
        [DataRow(50.0, 40.9, 9.1)]
        public void ShouldReturnFalseIfSumIsEqualOrGreaterThan100(double bf, double b, double w){
            var sut = new PercentSumWeightRecordRule();
            var result = sut.IsValid(new WeightRecord{
                BodyFatPercent = bf,
                BonesPercent = b,
                WaterPercent = w
            });
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        [DataRow(99.0, 0.5, 0.4)]
        [DataRow(50.0, 20.0, 10.0)]
        [DataRow(50.0, 40.9, 9.0)]
        public void ShouldReturnTrueIfSumIsLessThan100(double bf, double b, double w){
            var sut = new PercentSumWeightRecordRule();
            var result = sut.IsValid(new WeightRecord{
                BodyFatPercent = bf,
                BonesPercent = b,
                WaterPercent = w
            });
            Assert.AreEqual(true, result);
        }
    }
}