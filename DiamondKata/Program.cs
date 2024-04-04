using NewDay.DiamondKata;

while (true)
{
    Console.WriteLine("Type an alphabet letter");
    var input = Console.ReadLine();
    if (input == null || input.Length != 1 || !DiamondBuilder.Alphabet.Contains(input[0]))
    {
        Console.WriteLine("Incorrect input");
        continue;
    }

    var diamondBuilder = new DiamondBuilder();
    var diamond = diamondBuilder.Build(input[0]);
    diamond.Print(new ConsoleDiamondPrinter());    
}
