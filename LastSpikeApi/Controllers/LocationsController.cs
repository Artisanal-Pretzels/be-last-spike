using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LastSpikeGoogleApi;

namespace LastSpikeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        [HttpGet]
        public dynamic Get()
        {
            var request = new DistanceMatrix();
            var response = request.GetGarageDistances();
            Console.WriteLine(response);
            return response;
        }
    }
}