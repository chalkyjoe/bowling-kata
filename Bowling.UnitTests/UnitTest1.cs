using Bowling.Application;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Bowling.UnitTests
{
    public class Tests
    {
        private ScoreCalculator _scoreCalculator = new ScoreCalculator();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateScore_NoPinsHit_ScoreIsZero()
        {
            var points = _scoreCalculator.CalculatePoints("-- -- -- -- -- -- -- -- -- --");
            Assert.AreEqual(0, points);
        }

        [Test]
        public void CalculateScore_NoSparesOrStrikes_ScoreCalculatedCorrectly()
        {
            var points = _scoreCalculator.CalculatePoints("1- 1- 1- 1- 1- 1- 1- 1- 1- 1-");
            Assert.AreEqual(10, points);
        }

        [Test]
        public void CalculateScore_SingleSpare_ScoreCalculatedCorrectly()
        {
            var points = _scoreCalculator.CalculatePoints("1/ 1- -- -- -- -- -- -- -- --");
            Assert.AreEqual(11, points);
        }
    }
}