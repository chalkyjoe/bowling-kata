namespace Bowling.Application.Models
{
    public class Game
    {
        public Queue<Frame>? Frames { get; set; }
        private const int StrikeValue = 10;
        private const int SpareValue = 10;

        public Game(string scoreSheet)
        {
            Frames = ToFrames(scoreSheet);
        }

        public int CalculateTotalScore()
        {
            var totalScore = 0;
            var frames = new Queue<Frame>(Frames ?? throw new InvalidOperationException("No Frames found"));
            var lastPin = 0;
            var secondToLastPin = 0;
            while (frames.TryDequeue(out var frame))
            {

                totalScore += CaluclateCurrentFrame(lastPin, secondToLastPin, frame);

                if (frame.HasSpare)
                {
                    lastPin = frame.Rolls.First().Value;
                    secondToLastPin = SpareValue - lastPin;
                }
                else if (frame.HasStrike)
                {
                    secondToLastPin = lastPin;
                    lastPin = StrikeValue;
                }
                else
                {
                    lastPin = frame.Rolls.First().Value;
                    secondToLastPin = frame.Rolls.Last().Value;
                }
            }
            return totalScore;
        }



        private int CaluclateCurrentFrame(int next1, int next2, Frame currentFrame)
        {
            var currentFrameValue = CalculateFrameWithoutExtras(currentFrame);
            if (currentFrame.HasSpare) return SpareValue + next1;
            if (currentFrame.HasStrike) return StrikeValue + next2 + next1;
            return currentFrameValue;
        }

        private int CalculateFrameWithoutExtras(Frame frame)
        {
            return frame.Rolls.Sum(x => x.Value);
        }

        private Queue<Frame> ToFrames(string scoreSheet)
        {
            var frames = scoreSheet.Split(" ").Select(m => new Frame(m));
            return new Queue<Frame>(frames.Reverse());
        }
    }
}
