internal class Program
{
    public static void Main(string[] args)
    {
        var sr = new StreamReader("input.txt");
        var line = string.Empty;
        var sumTotal = 0;
        while ((line = sr.ReadLine()) is not null)
        {
            sumTotal += ParseLine(line.Where(char.IsDigit).ToArray());
            Console.WriteLine(sumTotal);
        }


        sr.Close();
        Console.ReadLine();
    }

    private static int ParseLine(char[] line)
    {
        Console.WriteLine($"{line.FirstOrDefault()}, {line.LastOrDefault()}");
        return 1;
    }
}