namespace Bowling.Application.Models
{
    public class Game
    {
        public LinkedList<Frame>? Frames { get; set; }

        public Game(string scoreSheet)
        {
            Frames = ToFrames(scoreSheet);
        }

        public int CalculateTotalScore()
        {
            var totalScore = 0;
            var frames = new LinkedList<Frame>(Frames ?? throw new InvalidOperationException("No Frames found"));
            var frameNode = frames.First;
            do
            {
                if (frameNode.Value.HasSpare)
                {
                    totalScore += CalculateFrameWithSpare(frameNode.Next.Value);
                }
                else if (frameNode.Value.HasStrike)
                {
                    totalScore += CalculateTotalScoreWithStrike(frameNode);
                }
                else
                {
                    totalScore += frameNode.Value.Score;
                }

                frameNode = frameNode.Next;
            } while (frameNode is not null);

            return totalScore;
        }

        private int CalculateTotalScoreWithStrike(LinkedListNode<Frame> frame)
        {
            var totalScore = 0;
            var nextFrame = frame.Next;

            if (!nextFrame.Value.HasStrike)
            {
                return frame.Value.Score + nextFrame.Value.Score;
            }

            var secondFrame = nextFrame.Next;

            return frame.Value.Score + nextFrame.Value.Score + secondFrame.Value.Rolls.First().Value;
        }

        private int CalculateFrameWithSpare(Frame nextFrame)
        {
            var nextRoll = nextFrame.Rolls.First().Value;
            var frameScore = nextRoll + 10;

            return frameScore;
        }

        private LinkedList<Frame> ToFrames(string scoreSheet)
        {
            var frames = scoreSheet.Split(" ").Select(m => new Frame(m));
            return new LinkedList<Frame>(frames);
        }
    }
}
