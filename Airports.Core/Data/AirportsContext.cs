using Airports.Core.Entities;
using Airports.Core.Models.SeedModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Airports.Core.Data
{
    public class AirportsContext : DbContext
    {
        public AirportsContext()
        {

        }
        public AirportsContext(DbContextOptions<AirportsContext> options)
           : base(options)
        {
        }

        public DbSet<Airport> Airports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<AirportSeedModel> items = new List<AirportSeedModel>();
            using (StreamReader r = new StreamReader($@"StaticData\airports.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<AirportSeedModel>>(json);
            }
            modelBuilder.Entity<Airport>().HasData(items.Where(a => !string.IsNullOrEmpty(a.iata_code)).Select(a => new Airport
            {
                ScheduledService = a.scheduled_service,
                IATACode = a.iata_code,
                Continent = a.continent,
                Country = a.iso_country,
                Elevation = a.elevation_ft,
                GPSCode = a.gps_code,
                HomeLink = a.home_link,
                Ident = a.ident,
                Id = int.Parse(a.id),
                Latitude = a.latitude_deg,
                Longitude = a.longitude_deg,
                LocalCode = a.local_code,
                Municipality = a.municipality,
                Name = a.name,
                Region = a.iso_region,
                Type = a.type,
                Wikipedia = a.wikipedia_link
            }));
            base.OnModelCreating(modelBuilder);
        }
    }
}
