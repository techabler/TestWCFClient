using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsole
{
    public class Car
    {
        private int wheelCount = 0;
        private string color = "RED";

        public Car() 
        { 
            wheelCount = 4;
        }

        public void description()
        {
            Console.WriteLine($"Wheel Count :{wheelCount}, Car color is {color}");
        }
    }
}
