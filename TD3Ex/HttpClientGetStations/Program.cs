using System;
using HttpClientOpenData;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
namespace HttpClientGetStations
{
    public class HttpClientGetStationsClass
    {
        public static HttpClient client = new HttpClient();

        public static async Task<Station[]> GetStationsByContract(string contract)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v3/stations?contract=" + contract + "&apiKey=" + InfoClient.key);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Station[] stations = JsonSerializer.Deserialize<Station[]>(responseBody);
                return stations;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return new Station[0];
        }
        static async Task Main(string[] args)
        {
            Station[] stations = await GetStationsByContract(args[0]);
            string jsonString = JsonSerializer.Serialize(stations);
            Console.WriteLine(jsonString);
            Console.ReadLine();

        }
    }
}

