using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
namespace WebServiceClient
{

    internal class Program
    {
        /**
         * Question 5 TD2
         * Client Web qui invoque une méthode incr <param1_val> (qui incrémente la valeur de val) d'un Web Service, communication M2M.
         * localhost:8080/webservice/incr?val=5
         * Il faut lancer WebService et WebServiceClient.
         */

        static HttpClient client = new HttpClient();

        static async Task Incr(int value )
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:8080/webservice/incr?val="+value);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
        private static void Main(string[] args)
        {
            Incr(1).GetAwaiter().GetResult();
            Console.ReadLine();

        }
    }
}