using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airports.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportsService _airportsService;

        //TODO : add logger
        //Dependency injection used
        public AirportsController(IAirportsService airportsService)
        {
            _airportsService = airportsService;
        }

        /// <summary>
        /// Get all available airports from db
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //TODO : Add exception handling middlware
            try
            {
                return Ok(await _airportsService.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get airport details by it's IATA code
        /// </summary>
        /// <param name="iataCode">Airport's IATA code</param>
        /// <returns></returns>
        [HttpGet("{iataCode}")]
        public async Task<IActionResult> GetByIataCode(string iataCode)
        {
            //TODO : Add exception handling middlware
            try
            {
                return Ok(await _airportsService.GetByIataCodeAsync(iataCode));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Get distance between to airb=ports identified by their iata codes
        /// </summary>
        /// <param name="iata1">First airport IATA code</param>
        /// <param name="iata2">Second airport IATA codeparam>
        /// <returns></returns>
        [HttpGet("distance/{iata1}/{iata2}")]
        public async Task<IActionResult> GetDistance(string iata1, string iata2)
        {
            //TODO : Add exception handling middlware
            try
            {
                return Ok(await _airportsService.GetDistanceInMilesAsync(iata1, iata2));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}