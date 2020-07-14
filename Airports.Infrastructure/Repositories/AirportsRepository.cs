using Airports.Core.Data;
using Airports.Core.Entities;
using Airports.Core.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports.Infrastructure.Repositories
{
    public class AirportsRepository : RepositoryBase<Airport>, IAirportsRepository
    {
        public AirportsRepository(AirportsContext context) : base(context)
        {
        }

        public Task<Airport> GetByIataCodeAsync(string iata)
        {
            return Context.Airports.FirstOrDefaultAsync(e => e.IATACode.ToLower() == iata.ToLower());
        }
    }
}
