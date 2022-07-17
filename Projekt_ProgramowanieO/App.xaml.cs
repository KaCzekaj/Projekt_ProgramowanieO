using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Projekt_ProgramowanieO.Controls;
using Projekt_ProgramowanieO.Database;
using System;
using System.Windows;

namespace Projekt_ProgramowanieO
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<UserNameContolTextBox>();
                    services.AddSingleton<LoginWindowV2>();
                    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;", o => o.CommandTimeout(120)));
                }).Build();

            using (var serviceScope = _host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    services.GetRequiredService<UserNameContolTextBox>();
                    LoginWindowV2 loginWindow = services.GetRequiredService<LoginWindowV2>();
                    loginWindow.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
                }
            }
        }
    }
}
