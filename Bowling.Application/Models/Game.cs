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
            while (Frames.TryDequeue(out var frame))
            {
                if (frame.HasSpare)
                {
                    totalScore += CalculateFrame(frame, Frames.Peek());
                }
                else
                {
                    totalScore += CalculateFrame(frame);
                }
            }

            return totalScore;
        }

        private int CalculateFrame(Frame frame, Frame? nextFrame = null)
        {
            var frameScore = 0;

            if (nextFrame != null)
            {
                var nextRoll = nextFrame.Rolls.First().Value;
                frameScore = nextRoll + 10;
            }
            else
            {
                frameScore = frame.Rolls.Sum(x => x.Value);
            }

            return frameScore;
        }

        private Queue<Frame> ToFrames(string scoreSheet)
        {
            var frames = scoreSheet.Split(" ").Select(m => new Frame(m));
            return new Queue<Frame>(frames);
        }
    }
}
