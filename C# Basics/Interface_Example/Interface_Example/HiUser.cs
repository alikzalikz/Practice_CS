﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Example
{
    class HiUser : IMyInterface
    {
        public void ControlSpeed(int speed)
        {
            Console.WriteLine("Speed Control");
        }

        public string HelloUser(string name)
        {
            return "salam " + name;
        }
    }
}
