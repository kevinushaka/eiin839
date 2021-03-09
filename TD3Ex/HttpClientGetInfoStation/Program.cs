using System;
using HttpClientOpenData;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
namespace HttpClientGetInfoStation
{
    public class HttpClientGetInfoStationClass
    {
        public static HttpClient client = new HttpClient();

        public static async Task<Station> GetInfoStation(string contract, string stationNumber)
        {
            try
            {
                Console.WriteLine("https://api.jcdecaux.com/vls/v3/stations/" + stationNumber + "?contract=" + contract + "&apiKey=" + InfoClient.key);
                HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v3/stations/" + stationNumber + "?contract=" + contract + "&apiKey=" + InfoClient.key);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Station station = JsonSerializer.Deserialize<Station>(responseBody);
                return station;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return new Station();
        }
        static async Task Main(string[] args)
        {
            Station station = await GetInfoStation(args[0], args[1]);
            string jsonString = JsonSerializer.Serialize(station);
            Console.WriteLine(jsonString);
            Console.ReadLine();

        }
    }
}
