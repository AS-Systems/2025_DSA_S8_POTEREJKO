using LibraryManager.Model;
using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories;
using LibraryManager.Model.Repositories.Interfaces;
using LibraryManager.ViewModel.Converters.ImageConverter;
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
            serviceCollection.AddDbContext<HomelibraryContext>(options =>
                options.UseMySql("Server=mysql-home-library-sarass880-book-library.d.aivencloud.com;Port=13154;Database=HomeLibrary;Uid=avnadmin;Pwd=password;SslMode=Required;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"))); // Set your connection string here
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IBookRepository, BookRepository>();
            serviceCollection.AddScoped<IBorrowRepository, BorrowRepository>();
            serviceCollection.AddSingleton<IImageConverter, ImageConverter>();
            serviceCollection.AddSingleton<IBookshelfRepository, BookshelfRepository>();    

            ServiceProvider = serviceCollection.BuildServiceProvider();

            base.OnStartup(e);
        }
    }

}
