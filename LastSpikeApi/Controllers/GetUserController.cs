using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using FrontEndRequests;
using LastSpikeApi.Data;
using LastSpikeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LastSpikeApi.Controllers
{

    [Route ("api/user")]
    [ApiController]
    public class GetUserController : ControllerBase
    {
        private readonly LastSpikeContext _context;

        public GetUserController (LastSpikeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<User> Get ()
        {

            return _context.Users.ToList ();
        }

        [Route ("locations")]
        [HttpPost]
        public async Task<ActionResult<List<User>>> Post (UserLocation request)
        {
            double something = (double) request.longitude;
            double deltaLat = 0.05;
            double deltaLong = 0.007;

            var minLong = something - deltaLong;
            var maxLong = something + deltaLong;

            IEnumerable<User> returnVal = from u in _context.Users
            where u.Longitude < maxLong && u.Longitude > minLong
            select u;

            return returnVal.ToList ();
        }
    }
}