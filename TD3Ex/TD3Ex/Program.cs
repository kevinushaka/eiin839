using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using HttpClientOpenData;
namespace HttpClientGetContracts
{
    public class HttpClientGetContractsClass
    {
        public static HttpClient client = new HttpClient();

        public static async Task<Contract[]> GetContracts()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v3/contracts?&apiKey=" + InfoClient.key);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Contract[] contracts = JsonSerializer.Deserialize<Contract[]>(responseBody);
                return contracts;
                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return new Contract[0];
        }
        static async Task Main()
        {
            Contract[] contracts = await GetContracts();
            string jsonString = JsonSerializer.Serialize(contracts);
            Console.WriteLine(jsonString);
            Console.ReadLine();

        }
    }
}
