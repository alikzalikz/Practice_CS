namespace PrimeFactorsLib;
public static class PrimeFactors
{
    static public string Factor(int x)
    {
        string str = $"Prime factors of {x} are: ";
        int[] primeNum = new int[] {13, 11, 7, 5, 3, 2};

        bool endPrime = false;
        while(!endPrime)
        {
            if (x == 1)
            {
                str += 1;
                break;
            }
            foreach (int n in primeNum)
            {
                if (x % n == 0)
                {
                    x /= n;
                    str += n;
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

        return str;
    }
}
