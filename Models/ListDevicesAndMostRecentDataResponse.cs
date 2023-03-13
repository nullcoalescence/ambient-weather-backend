namespace ambient_weather_backend.Models
{
    using System;

    using Newtonsoft.Json;

    /*
     *  Response for the Ambient Weather endpoint 'List User's Devices'
     *  https://rt.ambientweather.net/v1/devices?applicationKey=&apiKey=
     */

        public class ListDevicesAndMostRecentDataResponse
    {
            [JsonProperty("macAddress")]
            public string MacAddress { get; set; }

            [JsonProperty("lastData")]
            public LastData LastData { get; set; }

            [JsonProperty("info")]
            public Info Info { get; set; }
        }

        public partial class Info
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("coords")]
            public InfoCoords Coords { get; set; }
        }

        public partial class InfoCoords
        {
            [JsonProperty("coords")]
            public CoordsCoords Coords { get; set; }

            [JsonProperty("address")]
            public string Address { get; set; }

            [JsonProperty("location")]
            public string Location { get; set; }

            [JsonProperty("elevation")]
            public double Elevation { get; set; }

            [JsonProperty("geo")]
            public Geo Geo { get; set; }
        }

        public partial class CoordsCoords
        {
            [JsonProperty("lat")]
            public double Lat { get; set; }

            [JsonProperty("lon")]
            public double Lon { get; set; }
        }

        public partial class Geo
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("coordinates")]
            public double[] Coordinates { get; set; }
        }

        public partial class LastData
        {
            [JsonProperty("dateutc")]
            public long Dateutc { get; set; }

            [JsonProperty("tempinf")]
            public double Tempinf { get; set; }

            [JsonProperty("humidityin")]
            public long Humidityin { get; set; }

            [JsonProperty("baromrelin")]
            public double Baromrelin { get; set; }

            [JsonProperty("baromabsin")]
            public double Baromabsin { get; set; }

            [JsonProperty("tempf")]
            public double Tempf { get; set; }

            [JsonProperty("battout")]
            public long Battout { get; set; }

            [JsonProperty("humidity")]
            public long Humidity { get; set; }

            [JsonProperty("winddir")]
            public long Winddir { get; set; }

            [JsonProperty("windspeedmph")]
            public double Windspeedmph { get; set; }

            [JsonProperty("windgustmph")]
            public double Windgustmph { get; set; }

            [JsonProperty("maxdailygust")]
            public double Maxdailygust { get; set; }

            [JsonProperty("hourlyrainin")]
            public long Hourlyrainin { get; set; }

            [JsonProperty("eventrainin")]
            public long Eventrainin { get; set; }

            [JsonProperty("dailyrainin")]
            public long Dailyrainin { get; set; }

            [JsonProperty("weeklyrainin")]
            public long Weeklyrainin { get; set; }

            [JsonProperty("monthlyrainin")]
            public double Monthlyrainin { get; set; }

            [JsonProperty("totalrainin")]
            public double Totalrainin { get; set; }

            [JsonProperty("solarradiation")]
            public double Solarradiation { get; set; }

            [JsonProperty("uv")]
            public long Uv { get; set; }

            [JsonProperty("batt_co2")]
            public long BattCo2 { get; set; }

            [JsonProperty("feelsLike")]
            public double FeelsLike { get; set; }

            [JsonProperty("dewPoint")]
            public double DewPoint { get; set; }

            [JsonProperty("feelsLikein")]
            public long FeelsLikein { get; set; }

            [JsonProperty("dewPointin")]
            public double DewPointin { get; set; }

            [JsonProperty("lastRain")]
            public DateTimeOffset LastRain { get; set; }

            [JsonProperty("tz")]
            public string Tz { get; set; }

            [JsonProperty("date")]
            public DateTimeOffset Date { get; set; }
    }
}
