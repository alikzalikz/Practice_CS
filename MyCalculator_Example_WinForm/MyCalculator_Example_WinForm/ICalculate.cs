using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator_Example_WinForm
{
    interface ICalculate
    {
        int Sum(int a, int b);
        int Minus(int a, int b);
        int Multiple(int a, int b);
        int Divide(int a, int b);
    }
}
