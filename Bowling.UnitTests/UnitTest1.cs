using Bowling.Application;

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

        [TestCase("1/ 1- -- -- -- -- -- -- -- --", 12)]
        [TestCase("1/ 5/ 9- -- -- -- -- -- -- --", 43)]
        [TestCase("1/ 1/ 1/ 1/ 1/ 1/ 1/ 1/ 1/ 1-", 100)]
        public void CalculateScore_SingleSpare_ScoreCalculatedCorrectly(string scoreCard, int expectedResult)
        {
            var points = _scoreCalculator.CalculatePoints(scoreCard);
            Assert.AreEqual(expectedResult, points);
        }
    }
}