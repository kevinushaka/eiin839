using System;
using HttpClientOpenData;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
namespace HttpClientGetStations
{
    class Program
    {
        public static int number_station = 9087;
        public static HttpClient client = new HttpClient();
        static async Task Main()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v3/stations/"+ number_station + "?contract=marseille&apiKey=" + InfoClient.key);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Station[] contracts = JsonSerializer.Deserialize<Station[]>(responseBody);

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

