using System.Net.Http.Json;
using BlazorMovieDB.Models;
using BlazorMovieDB.Utilities;
using Microsoft.Extensions.Options;

namespace BlazorMovieDB.Services 
{    
    public class MovieDBService 
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string? _apiKey;

        public MovieDBService(HttpClient httpClient, IConfiguration config)
        {
            
            _config = config;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(Constants.baseUri);
            _httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));
            _apiKey = _config["Authentication:ApiKey"] ?? throw new Exception("MDB Key not found!");

        }

        public async Task<Movies> GetMovies()
        {
            try
            {
               
               Movies? response =  await _httpClient.GetFromJsonAsync<Movies>($"{Constants.discoverMovie}?api_key={_apiKey}");
               System.Diagnostics.Debug.WriteLine(response);
               return response;
                
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.ToString());
            }

        }
    }
}
