namespace Bowling.Application.Models;

internal class Roll
{
    public int Value { get; set; }
    public Roll(char c)
    {
        if (int.TryParse(c.ToString(), out var value))
        {
            Value = value;
        }
    }
}