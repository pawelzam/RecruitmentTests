namespace NewDay.DiamondKata;
public class DiamondBuilder : IDiamondBuilder
{
    public const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public Diamond Build(char lastLetter)
    {
        var letters = GetAllDiamondLetters(lastLetter);

        var lines = new List<string>();
        for (int i = 0; i < letters.Length; i++)
        {
            var currentLetter = letters[i];
            var innerSpace = $"{new string('_', i > 0 ? (i * 2) - 1 : 0)}";
            var outerSpace = $"{new string('_', letters.Length - i - 1)}";
            var line = $"{outerSpace}{currentLetter}{innerSpace}{(i > 0 ? currentLetter + outerSpace : outerSpace)}";
            lines.Add(line);
        }

        var arr = lines.SkipLast(1).ToArray();
        Array.Reverse(arr);

        lines.AddRange(arr);

        return new Diamond([.. lines]);
    }

    public static string GetAllDiamondLetters(char letter) => 
        Alphabet.Contains(letter) ? 
            Alphabet[0..(Alphabet.IndexOf(letter) + 1)] : 
            throw new NotSupportedException($"Character {letter} is not supported");
}
