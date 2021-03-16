using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WebServiceClientSOAP.Calculator;
namespace WebServiceClientSOAP
{
    class Program
    {
        static void Main(string[] args)

            
        {
            CalculatorSoapClient client= new CalculatorSoapClient();
            Console.WriteLine(client.Add(1, 2));
            Console.ReadLine();
        }
    }
}
