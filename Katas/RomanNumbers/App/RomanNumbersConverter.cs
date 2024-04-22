using System.Text;

namespace Katas.RomanNumbers.App;

public class RomanNumbersConverter
{
    private static readonly Dictionary<int, string> RomanNumerals = new Dictionary<int, string>
    {
        { 1000, "M" },
        { 900, "CM" },
        { 500, "D" },
        { 400, "CD" },
        { 100, "C" },
        { 90, "XC" },
        { 50, "L" },
        { 40, "XL" },
        { 10, "X" },
        { 9, "IX" },
        { 5, "V" },
        { 4, "IV" },
        { 1, "I" }
    };

    public static string Convert(int number)
    {
        var output = new StringBuilder();
        foreach (var item in RomanNumerals)
        {
            while (number >= item.Key)
            {
                output.Append(item.Value);
                number -= item.Key;
            }
        }

        return output.ToString();
    }
}