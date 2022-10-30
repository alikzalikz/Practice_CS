using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_Example
{
    class Car
    {
        // pubilc other class
        // private just this doclass
        // protected just inheritnce class
        // internal all of this project and namespace

        private int _speed;

        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                if (value > 120)
                {
                    System.Console.WriteLine("mimiri badbakht!!");
                    _speed = 0;
                }
                else
                {
                    _speed = value;
                }
            }
        }

        private string _carName = "Pride";
        public string CarName
        {
            get
            {
                return _carName;
            }
        }

    }
}
