using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class BaseTest
    {
        protected static ServiceProvider serviceProvider;

        protected static IPdvService _pdvService;

        protected static IServiceCollection services;

        private static bool _initializeReady = false;

        protected IConfiguration configuration;

        [TestInitialize]
        public void TestInitialize()
        {
            if (_initializeReady == false)
            {
                configuration = IoCTest.GetIConfigurationRoot();

                services = IoCTest.ConfigureServices();

                serviceProvider = services.BuildServiceProvider();

                _pdvService = serviceProvider.GetRequiredService<IPdvService>();

                _initializeReady = true;
            }
        }
    }
}
