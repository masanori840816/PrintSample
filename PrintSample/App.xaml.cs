using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PrintSample.Main;
using PrintSample.Pdf;
using PrintSample.Prints;

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
            services.AddScoped<MainViewModel>();
            services.AddScoped<IPrinter, Printer>();
            services.AddScoped<IPdfLoader, PdfLoader>();
            //services.AddScoped<ISpreadsheetLoader, SpreadsheetLoader>();
            return services.BuildServiceProvider();
        }
    }
}
