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
        public void CalculateScore_NoSparesOrStrikes_ScoreCalculatedCorrectly()
        {
            var points = _scoreCalculator.CalculatePoints("22 22 22 22 22 22 22 22 22 22");
            Assert.AreEqual(40, points);
        }
    }
}