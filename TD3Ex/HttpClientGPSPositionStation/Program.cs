using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Device.Location;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;
namespace HttpClientGPSPositionStation
{
    class InfoClient
    {
        public static string key = "59f9558f2e403d30419e330b3e0da743626b0bfa";
    }

    class MyLogger : Logger
    {
        public override void Initialize(IEventSource eventSource)
        {
        }
    class Program
    {
        static HttpClient client = new HttpClient();
       
        public static void LogError(HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }

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
                LogError(e);
            }
            return new Station[0];
        }

        public static async Task<Station> GetNearestStation(string contract,GeoCoordinate gpsPosition)
        {
            Station[] stations = await GetStationsByContract(contract);
            double min= gpsPosition.GetDistanceTo(new GeoCoordinate(stations[0].position.latitude, stations[0].position.longitude));
            Station closestStation = new Station();
            for (int i =0;i<stations.Length;i++)
            {
                double distance =gpsPosition.GetDistanceTo(new GeoCoordinate(stations[i].position.latitude, stations[i].position.longitude));
                if(distance < min)
                {
                    min = distance;
                    closestStation = stations[i];
                }
            }
            return closestStation;
        }
        static async Task Main(string[] args)
        {
            double latitude = 43.3046818705083;
            double longitude = 5.3901483781149;
            Station station = await GetNearestStation("marseille",new GeoCoordinate(latitude,longitude));
            string jsonString = JsonSerializer.Serialize(station);
            Console.WriteLine(jsonString);
            Console.ReadLine();
        }
    }
}
