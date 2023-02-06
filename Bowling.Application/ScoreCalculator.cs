using Bowling.Application.Models;

namespace Bowling.Application
{
    public class ScoreCalculator
    {
        public int CalculatePoints(string scoreSheet)
        {
            int points = 0;
            var game = new Game(scoreSheet);
            points = game.CalculateTotalScore();
            return points;
        }
    }
}