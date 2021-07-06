using System.Threading.Tasks;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace WebUI.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddLoadingBar();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            await builder.Build().UseLoadingBar().RunAsync();
        }
    }
}

//namespace WebUI.Client
//{
//    public class Program
//    {
//        public static async Task Main(string[] args)
//        {
//            var builder = WebAssemblyHostBuilder.CreateDefault(args);
//            builder.RootComponents.Add<App>("app");
//            builder.Services.AddLoadingBar();

//            await builder.Build().UseLoadingBar().RunAsync();
//        }
//    }
//}
