using SchoolForms.JsonObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SchoolForms
{
    public class WeatherApiHandler
    {
        string uriWeather = "http://api.weatherstack.com/";
        string patWeather = "fef4e1f4142b0bb9fea87bf29247c68a";
        HttpClient httpClient;

        /// <summary>
        /// Constructor for the weatherstack API handler
        /// </summary>
        public WeatherApiHandler()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(uriWeather);
        }
        /// <summary>
        /// [GET] /current endpoint
        /// Get's the temperature in Celcius of the chosen city
        /// </summary>
        /// <param name="city">City to check the weather from</param>
        /// <returns>numeric temperature in celcius of the searched City</returns>
        public async Task<string> GetWeather(string city)
        {
            string currentWeatherEndpoint = $"current?access_key={patWeather}&query={city}";
            var request = new HttpRequestMessage(HttpMethod.Get, currentWeatherEndpoint);
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            using var responseStream = response.Content.ReadAsStreamAsync();
            var objCurrentWeather = await JsonSerializer.DeserializeAsync<CurrentWeather>(await responseStream);
            return objCurrentWeather!.current.temperature.ToString();
        }
    }
}
