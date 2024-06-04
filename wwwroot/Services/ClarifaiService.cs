using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace SafErgyReal.Services
{
    public class ClarifaiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public ClarifaiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["Clarifai:ApiKey"];
            // Configure the HttpClient object
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Key", _apiKey);
        }

        public async Task<string> PredictFoodAsync(byte[] imageBytes)
        {
            var base64Image = Convert.ToBase64String(imageBytes);
            var url = $"https://api.clarifai.com/v2/models/food-item-recognition/versions/1d5fd481e0cf4826aa72ec3ff049e044/outputs";


            var requestContent = new
            {
                inputs = new[]
                {
                new
                {
                    data = new
                    {
                        image = new { base64 = base64Image }
                    }
                }
            }
            };

            var jsonRequest = JsonSerializer.Serialize(requestContent);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Key", _apiKey);

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to get a successful response from Clarifai");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse; // Consider further parsing this JSON response to extract the prediction results
        }
    }

}
