namespace Bowling.Application.Models
{
    public class Game
    {
        public Frame Frame { get; set; }

        public Game(string scoreSheet)
        {
            Frame = ToFrames(scoreSheet);
        }

        public int CalculateTotalScore()
        {
            int sum = 0;
            foreach (var currentFrame in Frame)
            {
                sum += currentFrame.CalculateScore();
            }

            return sum;
        }

        private Frame ToFrames(string scoreSheet)
        {
            var frames = new Queue<string>(scoreSheet.Split(" "));
            return new Frame(frames);
        }
    }
}
