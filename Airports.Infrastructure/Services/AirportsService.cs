using Airports.Core.Entities;
using Airports.Core.Models.ViewModels;
using Airports.Core.RepositoryInterfaces;
using Airports.Core.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports.Infrastructure.Services
{
    public class AirportsService : IAirportsService
    {
        private readonly IAirportsRepository _airportsRepository;
        public AirportsService(IAirportsRepository airportsRepository)
        {
            _airportsRepository = airportsRepository;
        }
        public async Task<List<AirportListViewModel>> GetAllAsync()
        {
            return await _airportsRepository.GetAll().Select(a => new AirportListViewModel
            {
                IATACode = a.IATACode,
                Id = a.Id,
                Name = a.Name
            }).ToListAsync();
        }

        public async Task<AirportViewModel> GetByIataCodeAsync(string iata)
        {
            var airport = await _airportsRepository.GetByIataCodeAsync(iata);
            return ConvertToViewModel(airport);
        }

        public async Task<double> GetDistanceInMilesAsync(string iata1, string iata2)
        {
            var airport1 = await _airportsRepository.GetByIataCodeAsync(iata1);
            var airport2 = await _airportsRepository.GetByIataCodeAsync(iata2);

            return CalculateDistance(airport1.Latitude, airport1.Longitude, airport2.Latitude, airport2.Longitude);
        }

        private AirportViewModel ConvertToViewModel(Airport entity)
        {
            return new AirportViewModel
            {
                IATACode = entity.IATACode,
                Continent = entity.Continent,
                Country = entity.Country,
                Elevation = entity.Elevation,
                GPSCode = entity.GPSCode,
                HomeLink = entity.HomeLink,
                Ident = entity.Ident,
                Latitude = entity.Latitude,
                LocalCode = entity.LocalCode,
                Longitude = entity.Longitude,
                Municipality = entity.Municipality,
                Name = entity.Name,
                Region = entity.Region,
                ScheduledService = entity.ScheduledService,
                Type = entity.Type,
                Wikipedia = entity.Wikipedia
            };
        }

        /// <summary>
        /// Calculates distance between 2 coordinates
        /// </summary>
        /// <param name="latitude">first coordinate latitude</param>
        /// <param name="longitude">first coordinate longitude</param>
        /// <param name="otherLatitude">second coordinate latitude</param>
        /// <param name="otherLongitude">second coordinate longitude</param>
        /// <returns></returns>
        private double CalculateDistance(double latitude, double longitude, double otherLatitude, double otherLongitude)
        {
            var d1 = latitude * (Math.PI / 180.0);
            var num1 = longitude * (Math.PI / 180.0);
            var d2 = otherLatitude * (Math.PI / 180.0);
            var num2 = otherLongitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
