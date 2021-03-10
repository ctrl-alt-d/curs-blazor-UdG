using LibTaller;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MyPrograma
{

    public class App : IApp
    {
        public App(ICotxe elMeuCotxe)
        {
            ElMeuCotxe = elMeuCotxe;
        }

        public ICotxe ElMeuCotxe { get; private set; } 

        public void Run()
        {
            ElMeuCotxe.Activa4Intermitents();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var services = new ServiceCollection();

            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            var app = serviceProvider.GetRequiredService<IApp>();

            app.Run();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IApp, App>();
            services.AddTransient<ICotxe, Cotxe>();
            services.AddTransient<IIntermitent, Intermitent>();
        }


    }
}
