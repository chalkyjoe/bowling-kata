namespace Bowling.Application.Models
{
    public class Game
    {
        public Queue<Frame>? Frames { get; set; }

        public Game(string scoreSheet)
        {
            Frames = ToFrames(scoreSheet);
        }

        public int CalculateTotalScore()
        {
            var totalScore = 0;
            var frames = new Queue<Frame>(Frames ?? throw new InvalidOperationException("No Frames found"));
            while (frames.TryDequeue(out var frame))
            {
                if (frame.HasSpare)
                {
                    totalScore += CalculateFrameWithSpare(frames.Peek());
                }
                else
                {
                    totalScore += CalculateFrame(frame);
                }
            }

            return totalScore;
        }

        private int CalculateFrame(Frame frame)
        {
            return frame.Rolls.Sum(x => x.Value);
        }

        private int CalculateFrameWithSpare(Frame nextFrame)
        {
            var nextRoll = nextFrame.Rolls.First().Value;
            var frameScore = nextRoll + 10;

            return frameScore;
        }

        private Queue<Frame> ToFrames(string scoreSheet)
        {
            var frames = scoreSheet.Split(" ").Select(m => new Frame(m));
            return new Queue<Frame>(frames);
        }
    }
}
