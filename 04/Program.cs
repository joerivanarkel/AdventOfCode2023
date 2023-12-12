// See https://aka.ms/new-console-template for more information
using day04;

Console.WriteLine("Hello, World!");

var input = GetInput();
var games = ParseInput(input);
var points = GetTotalPoints(games);

Console.WriteLine($"Total points: {points}");


List<string> GetInput()
    => File.ReadAllLines("input.txt").ToList();

List<Game> ParseInput(List<string> input)
{
    var games = new List<Game>();
    foreach (var item in input)
    {
        var game = new Game();
        var splitItem = item.Split(": ");
        game.Id = int.Parse(splitItem[0].Replace("Card ", ""));
        var splitNumbers = splitItem[1].Split(" | ");

        ParseWinningNumbers(game, splitNumbers);

        ParseYourNumbers(game, splitNumbers);

        games.Add(game);
    }
    return games;


    static void ParseWinningNumbers(Game game, string[] splitNumbers)
    {
        var winningNumbers = splitNumbers[0].Split(" ");
        var winningNumbersList = new List<int>();
        foreach (var number in winningNumbers)
        {
            if (number != string.Empty) 
            {
                winningNumbersList.Add(int.Parse(number));
            }
        }
        game.WinningNumbers = winningNumbersList;
    }

    static void ParseYourNumbers(Game game, string[] splitNumbers)
    {
        var yourNumbers = splitNumbers[1].Split(" ");
        var yourNumbersList = new List<int>();
        foreach (var number in yourNumbers)
        {
            if (number != string.Empty) 
            {
                yourNumbersList.Add(int.Parse(number));
            }
        }
        game.YourNumbers = yourNumbersList;
    }
}


int GetTotalPoints(List<Game> games)
    => games.Sum(game => game.Points[game.GetPoints()]);
