using SampleConsole.korean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // instance 생성 
            Car car_object = new Car();

            car_object.description();

            Truck truck = new Truck();


            var valueType = "float";
            var value = "45.1";

            var ValueTypeString = valueType == "float" ? "System.Single" : "System.Single";
            var result = Convert.ChangeType(value, Type.GetType(ValueTypeString));

            Console.WriteLine(result);



            Console.ReadKey();
        }
    }
}
