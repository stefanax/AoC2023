namespace AoC2023;

public class Day1
{
    private readonly InputFiles _inputFiles = new InputFiles();

    public void Step1()
    {
        var input = _inputFiles.ReadInputFileForDay(1, false);
        var inputList = _inputFiles.SplitString(input);

        var result = 0;

        foreach (var inputRow in inputList)
        {
            var firstNumber = '-';
            var lastNumber = '-';

            foreach (var inputRowCharacter in inputRow)
            {
                if (Char.IsDigit(inputRowCharacter)) {
                    if (firstNumber == '-') firstNumber = inputRowCharacter;
                    lastNumber = inputRowCharacter;
                }
            }

            result += Int32.Parse($"{firstNumber}{lastNumber}");
        }
        
        Console.WriteLine($"Step one result: {result}");
    }

    public void Step2()
    {
        var input = _inputFiles.ReadInputFileForDay(1, false);
        var inputList = _inputFiles.SplitString(input);

        var valuesList = new Dictionary<string, string>
        {
            { "1", "1" },
            { "2", "2" },
            { "3", "3" },
            { "4", "4" },
            { "5", "5" },
            { "6", "6" },
            { "7", "7" },
            { "8", "8" },
            { "9", "9" },
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" },
        };
        
        var result = 0;

        foreach (var inputRow in inputList)
        {
            var firstNumber = "-";
            var lastNumber = "-";

            for (var i = 0; i < inputRow.Length; i++)
            {
                foreach (var value in valuesList)
                {
                    var testString = "BANANA!!!";
                    try
                    {
                        testString = inputRow.Substring(i, value.Key.Length);
                    }
                    catch
                    {
                        // Index out of bounds. I can make a nice solution, or just do this. I did this.
                    }

                    if (value.Key == testString)
                    {
                        if (firstNumber == "-") firstNumber = value.Value;
                        lastNumber = value.Value;
                    }
                }
            }

            result += Int32.Parse($"{firstNumber}{lastNumber}");
        }
        
        Console.WriteLine($"Step two result: {result}");
    }
}