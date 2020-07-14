using System;
using System.Collections.Generic;
using System.Text;

namespace Airports.Core.Entities
{
    public class Airport : BaseEntity
    {
        public string Ident { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Elevation { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Municipality { get; set; }
        public string ScheduledService { get; set; }
        public string GPSCode { get; set; }
        public string IATACode { get; set; }
        public string LocalCode { get; set; }
        public string HomeLink { get; set; }
        public string Wikipedia { get; set; }
    }
}
