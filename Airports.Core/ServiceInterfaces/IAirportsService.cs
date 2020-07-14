using Airports.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Airports.Core.ServiceInterfaces
{
    public interface IAirportsService
    {
        Task<List<AirportListViewModel>> GetAllAsync();
        Task<AirportViewModel> GetByIataCodeAsync(string iata);
        Task<double> GetDistanceInMilesAsync(string iata1, string iata2);
    }
}
