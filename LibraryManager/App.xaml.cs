using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace LibraryManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        // App startup
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();

            // Registering services with DI
            serviceCollection.AddDbContext<LibraryDBContext>(options =>
                options.UseMySql("server=192.168.0.207;database=homelibrary;user id=test;password=twoje_haslo;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.3.0-mysql"))); // Set your connection string here
            serviceCollection.AddScoped<IUserRepository, UserRepository>();

            ServiceProvider = serviceCollection.BuildServiceProvider();

            base.OnStartup(e);
        }
    }
}
