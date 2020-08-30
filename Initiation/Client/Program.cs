using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Initiation.Client.Services.Js;
using Initiation.Client.Services.Http;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;

namespace Initiation.Client
{
    public  class Constants
    {
        public const string Base_URL = "http://localhost:24197/";
    }
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddStorage();

            builder.Services.AddSingleton<IJsAlertifyService, JsAlertifyService>();            

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IHttpInstrumentService, HttpInstrumentService>();
            builder.Services.AddScoped<IHttpUserService, HttpUserService>();

            await builder.Build().RunAsync();
        }
    }
}
