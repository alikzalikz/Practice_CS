namespace PrimeFactorsLib;
public static class PrimeFactors
{
    public static string Factor(int x)
    {
        string str = $"Prime factors of {x} are: ";

        bool endPrime = false;
        while (!endPrime)
        {
            if (x == 1)
            {
                str += 1;
                break;
            }
            for (int i = x; i >= 0; i--)
            {
                if (Prime(i))
                {
                    if (x % i == 0)
                    {
                        x /= i;
                        str += i;
                        if (x == 1)
                        {
                            endPrime = true;
                            break;
                        }
                        else
                        {
                            str += " x ";
                            break;
                        }
                    }
                }
            }
        }

        return str;
    }
    public static bool Prime(int x)
    {
        if (x < 1)
        {
            return false;
        }
        int num = 1;

        for (int i = 2; i <= x; i++)
        {
            if (x % i == 0)
            {
                num++;
                if (num > 2)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
