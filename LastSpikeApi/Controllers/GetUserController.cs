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
    }
}