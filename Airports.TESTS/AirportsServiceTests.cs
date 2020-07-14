using Airports.Core.Data;
using Airports.Core.Entities;
using Airports.Core.RepositoryInterfaces;
using Airports.Core.ServiceInterfaces;
using Airports.Infrastructure.Repositories;
using Airports.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Airports.TESTS
{
    public class Tests : TestSetup
    {
        [Test]
        public async Task GetByIataCode_Test()
        {
            //Arrange
            var iataCode = "AAA";

            //Act
            var airport = await _airportService.GetByIataCodeAsync(iataCode);

            //Assert
            Assert.IsNotNull(airport);
        }

        [Test]
        public async Task GetDistanceInMilesAsync_Same_Test()
        {
            //Arrange
            var iataCode = "AAA";

            //Act
            var distance = await _airportService.GetDistanceInMilesAsync(iataCode, iataCode);

            //Assert
            Assert.AreEqual(distance, 0);
        }

        [Test]
        public async Task GetDistanceInMilesAsync_Test()
        {
            //Arrange
            var iataCode1 = "AAA";
            var iataCode2 = "BBB";

            //Act
            var distance = await _airportService.GetDistanceInMilesAsync(iataCode1, iataCode2);

            //Assert
            Assert.IsTrue(distance > 0);
        }
    }
}