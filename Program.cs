using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorMovieDB;
using BlazorMovieDB.Services;
using BlazorMovieDB.Options;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.Configure<Authentication>(builder.Configuration.GetSection("Authentication"));
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<MovieDBService>();

await builder.Build().RunAsync();
