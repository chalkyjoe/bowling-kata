namespace Bowling.Application.Models;

public class Roll
{
    public int Value { get; set; }
    public bool IsSpare { get; set; }
    public bool IsStrike { get; set; }
    public Roll(char c)
    {
        if (int.TryParse(c.ToString(), out var value))
        {
            Value = value;
        }
        else if (c == '/')
        {
            IsSpare = true;
            Value = 10;
        }
        else if (c == 'X')
        {
            IsStrike = true;
            Value = 10;
        }
    }
}