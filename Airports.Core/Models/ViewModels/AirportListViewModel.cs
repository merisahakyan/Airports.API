using System;
using System.Collections.Generic;
using System.Text;

namespace Airports.Core.Models.ViewModels
{
    public class AirportListViewModel
    {
        public int Id { get; set; }
        public string IATACode { get; set; }
        public string Name { get; set; }
    }
}
