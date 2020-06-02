using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TaskScheduler.UnobservedTaskException += (sender, eventArgs) =>
            {
                var exception = eventArgs.Exception?.Flatten()?.InnerExceptions?.FirstOrDefault();
                if (exception != null)
                {
                    Log.Error(exception, "Task exception.");
                }
                eventArgs.SetObserved();
            };
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().UseSerilog();
    }
}
