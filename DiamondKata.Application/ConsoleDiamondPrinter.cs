using NewDay.DiamondKata;

public class ConsoleDiamondPrinter : IDiamondPrinter
{
    public void Print(Diamond diamond)
    {
        foreach (var line in diamond.Rows)
        {
            Console.WriteLine(line);
        }
    }
}