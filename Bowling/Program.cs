using Bowling.Application;

ScoreCalculator calculator = new ScoreCalculator();
Console.WriteLine("Enter your scoresheet:");
var scoreSheet = Console.ReadLine();
var points = calculator.CalculatePoints(scoreSheet);
Console.WriteLine(points);
