partial class Program
{
    static void TimesTable(byte number, byte size = 12)
    {
        WriteLine($"This is the {number} times table with {size} rows:");
        for (int row = 1; row <= size; row++)
        {
            WriteLine($"{row} x {number} = {row * number}");
        }
        WriteLine();
    }
    static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
    {
        decimal rate = 0.0M;
        rate = twoLetterRegionCode.ToUpper() switch
        {
            "CH" => 0.08M, 
            "DK" or "NO" => 0.25M, 
            "GB" or "FR" => 0.2M, 
            "HU" => 0.27M, 
            "OR" or "AK" or "MT" => 0.0M, 
            "ND" or "WI" or "ME" or "VA" => 0.05M, 
            "CA" => 0.0825M,
            _ => 0.06M 
        };
        return amount * rate;
    }

/// <summary>
/// Pass a 32-bit integer and it will be converted into its ordinal 1equivalent.
/// </summary>
/// <param name="number">
/// Number as a cardinal value e.g. 1, 2, 3, and so on.
/// </param>
/// <returns>
/// Number as an ordinal value e.g. 1st, 2nd, 3rd, and so on.
/// </returns>
    static string CardinalToOrdinal(int number)
    {
        int lastTwoDigits = number % 100;
        string str;
        str = lastTwoDigits switch
        {
            11 or 12 or 13 => $"{number:N0}th",
            _ when number % 10 == 1 => $"{number:N0}st",
            _ when number % 10 == 2 => $"{number:N0}nd", 
            _ when number % 10 == 3 => $"{number:N0}rd",
            _ => $"{number}th"
        };
        return str;
    }

    static int Factorial(int number)
    {
        int res;
        checked
        {
            res = number switch
            {
                < 0 =>  throw new ArgumentException(message: 
                        $"The factorial function is defined for non-negative integersonly. Input: {number}", 
                        paramName: nameof(number)),
                0 => 1,
                _ => number * Factorial(number - 1)
            };
        }
        return res;
    }

    static int FibImperative(int number) => number switch
    {
        1 => 0,
        2 => 1,
        _ => FibImperative(number - 1) + FibImperative(number - 2)
    };
}

 
// switch (twoLetterRegionCode.ToUpper())
// {
//     case "CH": // Switzerland
//         rate = 0.08M;
//         break;
//     case "DK": // Denmark
//     case "NO": // Norway
//         rate = 0.25M;
//         break;
//     case "GB": // United Kingdom
//     case "FR": // France
//         rate = 0.2M;
//         break;
//     case "HU": // Hungary
//         rate = 0.27M;
//         break;
//     case "OR": // Oregon
//     case "AK": // Alaska
//     case "MT": // Montana
//         rate = 0.0M;
//         break;
//     case "ND": // North Dakota
//     case "WI": // Wisconsin
//     case "ME": // Maine
//     case "VA": // Virginia
//         rate = 0.05M;
//         break;
//     case "CA": // California
//         rate = 0.0825M;
//         break;
//     default: // most US states
//         rate = 0.06M;
//         break;
// }


// switch (lastTwoDigits)
// {
//     case 11: // special cases for 11th to 13th
//     case 12:
//     case 13:
//         return $"{number:N0}th";

//     default:
//         int lastDigit = number % 10;
//         string suffix = lastDigit switch
//         {
//             1 => "st",
//             2 => "nd",
//             3 => "rd",
//             _ => "th"
//         };
//         return $"{number:N0}{suffix}";
// }