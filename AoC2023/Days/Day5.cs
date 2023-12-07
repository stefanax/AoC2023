namespace AoC2023;

public class Day5
{
    private class InternalMap
    {
        public Int64 DestinationStart;
        public Int64 SourceStart;
        public Int64 RangeLength;

        public InternalMap(Int64 destinationStart, Int64 sourceStart, Int64 rangeLength)
        {
            DestinationStart = destinationStart;
            SourceStart = sourceStart;
            RangeLength = rangeLength;
        }

        public Int64? GetDestinationValue(Int64 sourceValue)
        {
            if (sourceValue >= SourceStart && sourceValue < SourceStart + RangeLength)
            {
                return DestinationStart + sourceValue - SourceStart;
            }

            return null;
        }
    }
    
    
    private readonly InputFiles _inputFiles = new InputFiles();
    private List<Int64> seeds = new List<Int64>();

    public void Step1()
    {
        var input = _inputFiles.ReadInputFileForDay(5, false);
        var inputList = _inputFiles.SplitString(input);

        var lowestLocationNumber = Int64.MaxValue;

        var seeds = new List<Int64>();
        
        var seedToSoil = new List<InternalMap>();
        var soilToFertilizer = new List<InternalMap>();
        var fertilizerToWater = new List<InternalMap>();
        var waterToLight = new List<InternalMap>();
        var lightToTemperature = new List<InternalMap>();
        var temperatureToHumidity = new List<InternalMap>();
        var humidityToLocation = new List<InternalMap>();

        List<InternalMap> currentMap = seedToSoil;

        foreach (var inputRow in inputList)
        {
            if (inputRow.Length > 5 && inputRow.Substring(0, 5) == "seeds")
            {
                var seedsStringParts = inputRow.Split(" ");
                for (var i = 1; i < seedsStringParts.Length; i++)
                {
                    seeds.Add(Int64.Parse(seedsStringParts[i]));
                }
            }
            else
            {
                switch (inputRow)
                {
                    case "": continue;
                    case "seed-to-soil map:": currentMap = seedToSoil;
                        break;
                    case "soil-to-fertilizer map:": currentMap = soilToFertilizer;
                        break;
                    case "fertilizer-to-water map:": currentMap = fertilizerToWater;
                        break;
                    case "water-to-light map:": currentMap = waterToLight;
                        break;
                    case "light-to-temperature map:": currentMap = lightToTemperature;
                        break;
                    case "temperature-to-humidity map:": currentMap = temperatureToHumidity;
                        break;
                    case "humidity-to-location map:": currentMap = humidityToLocation;
                        break;
                    default:
                        var rangeParts = inputRow.Split(" ");
                        currentMap.Add(new InternalMap(Int64.Parse(rangeParts[0]), Int64.Parse(rangeParts[1]), Int64.Parse(rangeParts[2])));
                        break;
                }
            }
        }

        foreach (var seed in seeds)
        {
            var currentValueToTest = seed;
            foreach (var internalMap in seedToSoil)
            {
                var tempValue = internalMap.GetDestinationValue(currentValueToTest);
                if (tempValue == null) continue;
                currentValueToTest = tempValue ?? -1;
                break;
            }

            foreach (var internalMap in soilToFertilizer)
            {
                var tempValue = internalMap.GetDestinationValue(currentValueToTest);
                if (tempValue == null) continue;
                currentValueToTest = tempValue ?? -1;
                break;
            }

            foreach (var internalMap in fertilizerToWater)
            {
                var tempValue = internalMap.GetDestinationValue(currentValueToTest);
                if (tempValue == null) continue;
                currentValueToTest = tempValue ?? -1;
                break;
            }

            foreach (var internalMap in waterToLight)
            {
                var tempValue = internalMap.GetDestinationValue(currentValueToTest);
                if (tempValue == null) continue;
                currentValueToTest = tempValue ?? -1;
                break;
            }

            foreach (var internalMap in lightToTemperature)
            {
                var tempValue = internalMap.GetDestinationValue(currentValueToTest);
                if (tempValue == null) continue;
                currentValueToTest = tempValue ?? -1;
                break;
            }

            foreach (var internalMap in temperatureToHumidity)
            {
                var tempValue = internalMap.GetDestinationValue(currentValueToTest);
                if (tempValue == null) continue;
                currentValueToTest = tempValue ?? -1;
                break;
            }

            foreach (var internalMap in humidityToLocation)
            {
                var tempValue = internalMap.GetDestinationValue(currentValueToTest);
                if (tempValue == null) continue;
                currentValueToTest = tempValue ?? -1;
                break;
            }

            if (currentValueToTest < lowestLocationNumber) lowestLocationNumber = currentValueToTest;
        }


        Console.WriteLine($"Day 5 Step 1: {lowestLocationNumber}");
    }

    
    public void Step2()
    {
        var input = _inputFiles.ReadInputFileForDay(5, true);
        var inputList = _inputFiles.SplitString(input);

        var result = 0;

    }
}