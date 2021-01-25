using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PrintSample.Main;

namespace PrintSample
{
    public partial class App : Application
    {
        public void Start(object sender, StartupEventArgs e)
        {
            var servicesProvider = BuildService();
            using (servicesProvider as IDisposable)
            {
                var main = servicesProvider.GetRequiredService<MainWindow>();
                main.Show();
            }
        }
        private static IServiceProvider BuildService()
        {
            var services = new ServiceCollection();
            services.AddScoped<MainWindow>();
            //services.AddScoped<MainViewModel>();
            //services.AddScoped<ISpreadsheetLoader, SpreadsheetLoader>();
            return services.BuildServiceProvider();
        }
    }
}
