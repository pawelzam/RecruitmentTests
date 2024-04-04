namespace NewDay.DiamondKata;

public class Diamond(string[] rows)
{
    public string[] Rows { get; } = rows;

    public void Print(IDiamondPrinter printer)
    {
        printer.Print(this);
    }
}
