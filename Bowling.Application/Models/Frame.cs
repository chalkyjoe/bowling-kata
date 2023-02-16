using System.Collections;

namespace Bowling.Application.Models;

public record Frame : IEnumerable<Frame>
{
    public IEnumerable<Roll> Rolls { get; set; }
    public bool HasSpare => Rolls.Last().IsSpare;
    public bool HasStrike => Rolls.First().IsStrike;
    public int Score => HasSpare || HasStrike ? 10 : Rolls.Sum(m => m.Value);
    public Frame? NextFrame { get; set; }
    public Frame(Queue<string> frameQueue)
    {
        var frame = frameQueue.Dequeue();
        Rolls = frame.Select(m => new Roll(m));
        if (frameQueue.Count != 0)
            NextFrame = new Frame(frameQueue);
    }

    public int CalculateScore()
    {
        var totalScore = Score;
        if (HasSpare)
        {
            return totalScore + NextFrame.Rolls.First().Value;
        }

        if (HasStrike)
        {
            return CalculateStrikeScore(totalScore);
        }

        return totalScore;
    }

    private int CalculateStrikeScore(int totalScore)
    {
        var nextFrame = NextFrame;

        if (nextFrame is null) 
            return totalScore;
        totalScore += nextFrame.Score;

        if (nextFrame.HasStrike)
        {
            var secondFrame = nextFrame.NextFrame;
            totalScore += secondFrame?.Rolls.First().Value ?? 0;
                
        }

        return totalScore;
    }

    public IEnumerator<Frame> GetEnumerator()
    {
        var head = this;
        do
        {
            yield return head;
            head = head.NextFrame;
        } while (head is not null);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}