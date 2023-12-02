namespace AoC_1;

internal static class Program
{
    public static void Main(string[] args)
    {
        var sr = new StreamReader("input.txt");
        var sumTotal = 0;
        var line = string.Empty;
        while ((line = sr.ReadLine()) is not null)
        {
            var parsedLine = line.Where(char.IsDigit).ToArray();
            sumTotal += int.Parse($"{parsedLine.First()}{parsedLine.Last()}");
        }
        sr.Close();
        Console.WriteLine(sumTotal);
    }
    
}