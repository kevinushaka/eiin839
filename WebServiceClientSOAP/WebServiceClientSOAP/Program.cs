using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WebServiceClientSOAP.Calculator;
using WebServiceClientSOAP.MathsOperations;
namespace WebServiceClientSOAP
{
    class Program
    {
        static void Main(string[] args)

            
        {
            //CalculatorSoapClient client= new CalculatorSoapClient();
            MathsOperationsClient client = new MathsOperationsClient();
            Console.WriteLine(client.Add(1, 2));
            Console.ReadLine();
        }
    }
}
