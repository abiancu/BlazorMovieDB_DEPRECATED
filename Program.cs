using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorMovieDB;
using BlazorMovieDB.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
var apiKey = builder.Configuration["AppSettings:API_KEY"];
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<MovieDBService>();

await builder.Build().RunAsync();
