using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Projekt_ProgramowanieO.Controls;
using Projekt_ProgramowanieO.Database;
using System;
using System.Windows;

namespace Projekt_ProgramowanieO //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(@"Server=localhost\\SQLExpress,1433;Initial Catalog=CarRent;Integrated Security=SSPI;", o => o.CommandTimeout(120)));
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CarRent;Trusted_Connection=True;", o => o.CommandTimeout(120));
            });

            services.AddSingleton<LoginWindowV2>();
           
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            LoginWindowV2 loginWindow = serviceProvider.GetService<LoginWindowV2>();
            loginWindow.Show();
        }
    }
}
