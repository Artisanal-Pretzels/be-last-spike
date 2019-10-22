using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using GoogleApi.Entities.Maps.DistanceMatrix.Response;
using GoogleApi.Exceptions;
using GoogleApi;

namespace LastSpikeGoogleApi
{
    public class DistanceMatrix
    {

        public dynamic GetGarageDistances()
        {
            var request = new DistanceMatrixRequest
                {
                    Key = "AIzaSyBP5k0v5Upmr3TzZJEsrjUaazhFWqRf1uA",
                    Origins = new[] { new Location(40.7141289, -73.9614074) },
                    Destinations = new[] { new Location("185 Broadway Ave, Manhattan, NY, USA") }
                };
            var response = GoogleMaps.DistanceMatrix.Query(request);
            Console.WriteLine("Hello I'm the response");
            var stuff = response.Rows.First().Elements.First();
            return stuff;
        }
    }
}
