using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using HttpClientOpenData;
namespace HttpClientGetContracts
{
    class Program
    {
        public static HttpClient client = new HttpClient();
        static async Task Main()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v3/contracts?&apiKey="+InfoClient.key);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Contract[] contracts = JsonSerializer.Deserialize<Contract[]>(responseBody);

                string jsonString = JsonSerializer.Serialize(contracts);
                Console.WriteLine(jsonString);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            Console.ReadLine();

        }
    }
}
