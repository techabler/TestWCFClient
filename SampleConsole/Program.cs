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
            //Car car_object = new Car();

            //car_object.description();

            //Truck truck = new Truck();


            //var valueType = "float";
            //var value = "45.1";

            //var ValueTypeString = valueType == "float" ? "System.Single" : "System.Single";
            //var result = Convert.ChangeType(value, Type.GetType(ValueTypeString));

            //Console.WriteLine(result);

            double a = 0.123456719;
            double b = a * 1000 * 1000;
            // 1234567.89

            double p = b;

            Console.WriteLine(p.ToString());

            Console.WriteLine(p.ToString("000000"));

            var posit = p.ToString("000000");

            Console.WriteLine(posit.PadLeft(7));

            // Console.WriteLine(string.Format("{0:D7}", p));

            double D = -0.123456719;
            double E = D * 1000 * 1000;
            // 1234567.89

            double P = E;

            Console.WriteLine(P.ToString());
            Console.WriteLine(P.ToString("000000"));



            Console.ReadKey();
        }
    }
}
