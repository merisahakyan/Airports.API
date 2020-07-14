using Airports.Core.Data;
using Airports.Core.Entities;
using Airports.Core.RepositoryInterfaces;
using Airports.Core.ServiceInterfaces;
using Airports.Infrastructure.Repositories;
using Airports.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airports.TESTS
{
    public class TestSetup
    {
        protected IAirportsService _airportService;
        protected IAirportsRepository _airportRepository;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            //Inject repositories
            services.AddTransient<IAirportsRepository, AirportsRepository>();

            //Inject services
            services.AddTransient<IAirportsService, AirportsService>();

            services.AddDbContext<AirportsContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });

            var serviceProvider = services.BuildServiceProvider();

            _airportService = serviceProvider.GetService<IAirportsService>();
            _airportRepository = serviceProvider.GetService<IAirportsRepository>();

            SetupDatabase();
        }

        private void SetupDatabase()
        {
            _airportRepository.Add(new Airport
            {
                Id = 1,
                Continent = "test",
                Name = "test",
                IATACode = "AAA",
                Country = "PF",
                Latitude = -17.3526001,
                Longitude = -145.5099945
            });

            _airportRepository.Add(new Airport
            {
                Id = 2,
                Continent = "test",
                Name = "test",
                IATACode = "BBB",
                Country = "US",
                Latitude = 45.33190155,
                Longitude = -95.65059662
            });


            _airportRepository.SaveChanges();
        }
    }
}
