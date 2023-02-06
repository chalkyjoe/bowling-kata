namespace Bowling.Application
{
    public class ScoreCalculator
    {
        public int CalculatePoints(string scoreSheet)
        {
            int points = 0;
            var frames = scoreSheet.ToFrames();
            points = frames.Sum(m => m.CalculateScore());
            return points;
        }
    }
}