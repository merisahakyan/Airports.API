using Airports.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Airports.Core.RepositoryInterfaces
{
    public interface IAirportsRepository : IRepositoryBase<Airport>
    {
        Task<Airport> GetByIataCodeAsync(string iata);
    }
}
