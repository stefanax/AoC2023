using System.Reflection.Metadata;

namespace AoC2023;

public class Day3
{
    private readonly InputFiles _inputFiles = new InputFiles();
    
    public void Step1()
    {
        var input = _inputFiles.ReadInputFileForDay(3, false);
        var inputList = _inputFiles.SplitString(input);

        var result = 0;

        var grid = new List<List<char>>();
        var gridX = 0;
        var gridY = 0;

        foreach (var inputRow in inputList)
        {
            grid.Add(new List<char>()); 
            foreach (var inputChar in inputRow)
            {
                grid[gridY].Add(inputChar);
            }

            gridY++;
        }

        for (var posY = 0; posY < grid.Count; posY++)
        {
            for (var posX = 0; posX < grid[0].Count; posX++)
            {
                if (Char.IsDigit(grid[posY][posX]))
                {
                    var numberLength = 1;
                    for (int i = 1; i < 10; i++)
                    {
                        try
                        {
                            if (Char.IsDigit(grid[posY][posX + i]))
                            {
                                numberLength++;
                            }
                            else
                            {
                                i = 100; //Break loop old-school style
                            }
                        }
                        catch
                        {
                            i = 100;
                        }
                    }

                    var shouldBeAdded = false;
                    for (var i = -1; i <= 1 ; i++)
                    {
                        for (var j = -1; j <= numberLength; j++)
                        {
                            try
                            {
                                if (grid[posY + i][posX + j] != '.' && !Char.IsDigit(grid[posY + i][posX + j]))
                                {
                                    shouldBeAdded = true;
                                }
                            }
                            catch
                            {
                                //Ignore issues, probably outside the grid...
                            }
                        }
                    }

                    if (shouldBeAdded)
                    {
                        var valueString = "";
                        for (var i = 0; i < numberLength; i++)
                        {
                            valueString += grid[posY][posX + i].ToString();
                        }

                        result += Int32.Parse(valueString);
                    }
                    
                    posX += numberLength;
                }
            }
        }
        
        
        Console.WriteLine($"Step one result: {result}");
    }

    public void Step2()
    {
        var input = _inputFiles.ReadInputFileForDay(3, true);
        var inputList = _inputFiles.SplitString(input);

        var result = 0;
        
        var grid = new List<List<char>>();
        var gridX = 0;
        var gridY = 0;

        foreach (var inputRow in inputList)
        {
            grid.Add(new List<char>()); 
            foreach (var inputChar in inputRow)
            {
                grid[gridY].Add(inputChar);
            }

            gridY++;
        }
        
        
        for (var posY = 0; posY < grid.Count; posY++)
        {
            for (var posX = 0; posX < grid[0].Count; posX++)
            {
                if (Char.IsDigit(grid[posY][posX]))
                {
                    var numberLength = 1;
                    for (int i = 1; i < 10; i++)
                    {
                        try
                        {
                            if (Char.IsDigit(grid[posY][posX + i]))
                            {
                                numberLength++;
                            }
                            else
                            {
                                i = 100; //Break loop old-school style
                            }
                        }
                        catch
                        {
                            i = 100;
                        }
                    }

                    var shouldBeAdded = false;
                    for (var i = -1; i <= 1 ; i++)
                    {
                        for (var j = -1; j <= numberLength; j++)
                        {
                            try
                            {
                                if (grid[posY + i][posX + j] != '.' && !Char.IsDigit(grid[posY + i][posX + j]))
                                {
                                    shouldBeAdded = true;
                                }  //TODO: Find out if something is a * and...do something
                            }
                            catch
                            {
                                //Ignore issues, probably outside the grid...
                            }
                        }
                    }

//                    if (shouldBeAdded)
//                    {
//                        var valueString = "";
//                        for (var i = 0; i < numberLength; i++)
//                        {
//                            valueString += grid[posY][posX + i].ToString();
//                        }
//
//                        result += Int32.Parse(valueString);
//                    }
                    
                    posX += numberLength;
                }
            }
        }
        
        
        Console.WriteLine($"Step two result: {result}");
    }
}