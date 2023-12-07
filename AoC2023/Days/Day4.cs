using System.Collections;

namespace AoC2023;

public class Day4
{
    private readonly InputFiles _inputFiles = new InputFiles();

    public void Step1()
    {
        var input = _inputFiles.ReadInputFileForDay(4, false);
        var inputList = _inputFiles.SplitString(input);

        var result = 0;

        foreach (var inputRow in inputList)
        {
            var winningNumbers = 0;
            var card = System.Text.RegularExpressions.Regex.Split( inputRow, @"\s{1,}");

            for (var i = 2; i <= 11; i++)
            {
                for (var j = 13; j <= 37; j++)
                {
                    if (card[i] == card[j]) winningNumbers++;
                }
            }

            switch (winningNumbers)
            {
                case 0: break;
                case 1: result += 1;
                break;
                default:
                    var tempResult = 1;
                    for (var i = 1; i < winningNumbers; i++) tempResult *= 2;
                    result += tempResult;
                    break;
            }
        }
        
        Console.WriteLine($"Step one result: {result}");
    }

    public void Step2()
    {
        var input = _inputFiles.ReadInputFileForDay(4, false);
        var inputList = _inputFiles.SplitString(input);

        var result = 0;
        var wonCardsAmount = new List<int>{ 0 };

        
        foreach (var inputRow in inputList)
        {
            var winningNumbers = 0;
            var card = System.Text.RegularExpressions.Regex.Split( inputRow, @"\s{1,}");

            // for (var i = 2; i <= 6; i++)
            // {
            //     for (var j = 8; j <= 15; j++)
            //     {
            //         if (card[i] == card[j]) winningNumbers++;
            //     }
            // }

            for (var i = 2; i <= 11; i++)
            {
                for (var j = 13; j <= 37; j++)
                {
                    if (card[i] == card[j]) winningNumbers++;
                }
            }

            if (wonCardsAmount.Count > 0) 
            {
                wonCardsAmount[0]++; //We have always one one card.
            }
            else
            {
                wonCardsAmount.Add(1);
            }

            for (var i = 1; i <= winningNumbers; i++)
            {
                if (wonCardsAmount.Count <= i)
                {
                    wonCardsAmount.Add(wonCardsAmount[0]);
                }
                else
                {
                    wonCardsAmount[i] += wonCardsAmount[0];
                }
            }

            result += wonCardsAmount[0];
            wonCardsAmount.RemoveAt(0);
        }
        
        Console.WriteLine($"Step two result: {result}");
        
        
    }
}