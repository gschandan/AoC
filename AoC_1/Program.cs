using System.Diagnostics.Tracing;

namespace AoC_1;

internal static class Program
{
    public static void Main(string[] args)
    {
        using (var sr = new StreamReader("input.txt"))
        {
            var sumTotal = 0;
            var line = string.Empty;
            while ((line = sr.ReadLine()) is not null)
            {
                sumTotal += ParseDigits(line.AsSpan());
            }

            Console.WriteLine(sumTotal);
        }
    }

    private static Dictionary<string, string> _digits = new Dictionary<string, string>
    {
        { "one", "1" }, { "two", "2" }, { "three", "3" }, { "four", "4" }, { "five", "5" }, { "six", "6" },
        { "seven", "7" }, { "eight", "8" }, { "nine", "9" }
    };

    private static int ParseDigits(ReadOnlySpan<char> line)
    {
        var result = string.Empty;
        for (int i = 0; i < line.Length; i++)
        {
            if (char.IsDigit(line[i]))
            {
                result += line[i].ToString();
                continue;
            }

            if (char.IsLetter(line[i]))
            {
                foreach (var kvp in _digits)
                {
                    var length = kvp.Key.Length;
                    if (i + length <= line.Length && _digits.TryGetValue(line[i..(i + length)].ToString(), out var dig))
                    {
                        result += dig;
                        i += length - 1;
                    }
                }
            }
        }
        
        int digit = int.Parse(result[0..1] + result[^1..]);

        //Console.WriteLine($" {line}-> {result} : {result[0..1]}{result[^1..]} -> {digit}");
        return digit;
    }
}