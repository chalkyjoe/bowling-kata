namespace Bowling.Application.Models;

public record Frame
{
    public IEnumerable<Roll> Rolls { get; set; }
    public bool HasSpare { get; set; }
    public bool HasStrike { get; set; }
    public Frame(string frame)
    {
        Rolls = frame.Select(m => new Roll(m));
        HasSpare = Rolls.Last().IsSpare;
        HasStrike = Rolls.First().IsStrike;
    }
}