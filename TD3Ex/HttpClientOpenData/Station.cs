using System;
using System.Collections.Generic;
using System.Text;

namespace HttpClientOpenData
{
    public class Station
    {
        public int number { get; set; }
        public string contractName { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Position position { get; set; }
        public bool banking { get; set; }
        public bool bonus { get; set; }
        public string status { get; set; }
        public string lastUpdate { get; set; }
        public bool connected { get; set; }
        public bool overflow { get; set; }
        public object shape { get; set; }
        public Stands totalStands { get; set; }
        public Stands mainStands { get; set; }
        public Stands overflowStands { get; set; }
    }
}
