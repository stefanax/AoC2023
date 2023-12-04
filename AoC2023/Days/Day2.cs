namespace AoC2023;

public class Day2
{
    private readonly InputFiles _inputFiles = new InputFiles();

    public void Step1()
    {
        var input = _inputFiles.ReadInputFileForDay(2, false);
        var inputList = _inputFiles.SplitString(input);

        var result = 0;

        var redCubesInBag = 12;
        var greenCubesInBag = 13;
        var blueCubesInBag = 14;

        foreach (var inputRow in inputList)
        {
            var inputParts = inputRow.Split(" ");
            var gameNumber = inputParts[1].Replace(":", "");
            var gamePossible = true;

            for (var i = 2; i < inputParts.Length - 1; i += 2)
            {
                switch (inputParts[i+1].Replace(",", "").Replace(";", ""))
                {
                    case "red": if (Int32.Parse(inputParts[i]) > redCubesInBag) gamePossible = false;
                        break;
                    case "green": if (Int32.Parse(inputParts[i]) > greenCubesInBag) gamePossible = false;
                        break;
                    case "blue": if (Int32.Parse(inputParts[i]) > blueCubesInBag) gamePossible = false;
                        break;
                }
            }

            if (gamePossible) result += Int32.Parse(gameNumber);
        }
        
        Console.WriteLine($"Step one result: {result}");
    }

    public void Step2()
    {
        var input = _inputFiles.ReadInputFileForDay(2, false);
        var inputList = _inputFiles.SplitString(input);
        
        var result = 0;

        foreach (var inputRow in inputList)
        {
            var inputParts = inputRow.Split(" ");
            
            var minRedCubesInBag = 0;
            var minGreenCubesInBag = 0;
            var minBlueCubesInBag = 0;

            for (var i = 2; i < inputParts.Length - 1; i += 2)
            {
                switch (inputParts[i+1].Replace(",", "").Replace(";", ""))
                {
                    case "red": if (Int32.Parse(inputParts[i]) > minRedCubesInBag) minRedCubesInBag = Int32.Parse(inputParts[i]);
                        break;
                    case "green": if (Int32.Parse(inputParts[i]) > minGreenCubesInBag) minGreenCubesInBag = Int32.Parse(inputParts[i]);
                        break;
                    case "blue": if (Int32.Parse(inputParts[i]) > minBlueCubesInBag) minBlueCubesInBag = Int32.Parse(inputParts[i]);
                        break;
                }
            }

            result += minRedCubesInBag * minGreenCubesInBag * minBlueCubesInBag;
        }
        
        Console.WriteLine($"Step two result: {result}");
    }
}