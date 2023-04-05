using System;
using AlmisAssessment.Configuration;
using AlmisAssessment.Repository;
using AlmisAssessment.Services;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace AlmisAssessment
{
    public class Bootstrapper
    {
        private readonly Application _app;
        private IServiceCollection _services;
        private readonly IServiceProvider _serviceProvider;

        public Bootstrapper(Application app)
        {
            _app = app;
        }

        public void Start()
        {
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            _services = new ServiceCollection();
            _services.AddSingleton<IProductService, ProductService>();
            _services.AddSingleton<IRepository, Repository.Repository>();
        }
    }
}