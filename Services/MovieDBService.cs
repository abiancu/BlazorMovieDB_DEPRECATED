using System.Net.Http;
using System.Threading.Tasks;


namespace BlazorMovieDB.Services 
{    
    public class MovieDBService 
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public MovieDBService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }


    }
}