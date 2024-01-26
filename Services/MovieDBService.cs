using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorMovieDB.Utilities;

namespace BlazorMovieDB.Services 
{    
    public class MovieDBService 
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string? _apiKey;

        public MovieDBService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            _apiKey = config.GetValue<string>("AppSettings:API_KEY");
        }

        public async Task<HttpResponseMessage> GetMovies()
        {
            try
            {
                HttpResponseMessage? response = await _httpClient.GetAsync($"{Constants.baseUri}{Constants.discoverMovie}?apiKey={_apiKey}");
                
                if (response is not null) 
                {
                    return response;
                    
                }else
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
                }
                
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex}");
                throw;
            }

        }
    }
}
