using System.Runtime.Serialization.Json;
using System.Transactions;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LastSpikeApi.Models;
using LastSpikeApi.Data;
using System.Text.Json;
using Newtonsoft.Json;
using FrontEndRequests;

namespace LastSpikeApi.Controllers
{

    [Route("api/user")]
    [ApiController]
    public class GetUserController : ControllerBase
    {
        [HttpGet]
        public List<User> Get()
        {
            var context = new LastSpikeContext();
            return context.Users.ToList();
        }

        [Route("location")]
        [HttpPost]
        public async Task<ActionResult<List<User>>> Post(UserLocation request)
        {
            double something = (double)request.longitude;
            double deltaLat = 0.05;
            double deltaLong = 0.007;

            var minLong = something - deltaLong;
            var maxLong = something + deltaLong;

            var context = new LastSpikeContext();

            IEnumerable<User> returnVal = from u in context.Users
                            where u.Longitude < maxLong && u.Longitude > minLong
                            select u;

            return returnVal.ToList();
        }
    }
}