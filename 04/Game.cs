using System.Collections.Generic;
namespace day04;

public class Game
{
    public int Id { get; set; }
    public List<int>? WinningNumbers { get; set; }
    public List<int>? YourNumbers { get; set; }

    public Dictionary<int, int> Points { get; set; } = new()
    {
        { 0, 0 },
        { 1, 1 },
        { 2, 2 },
        { 3, 4 },
        { 4, 8 },
        { 5, 16 },
        { 6, 32 },
        { 7, 64 },
        { 8, 128 },
        { 9, 256 },
        { 10, 512 }
    };

    public override string ToString()
        => $"Game {Id}: {string.Join(" ", WinningNumbers)} | {string.Join(" ", YourNumbers)}";

    public int GetPoints()
    {
        var points = 0;
        foreach (var number in YourNumbers!)
        {
            if (WinningNumbers!.Contains(number))
            {
                points++;
            }
        }
        return points;
    }
}