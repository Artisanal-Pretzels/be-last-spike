using System;
using Xunit;
using LastSpikeGoogleApi;

namespace LastSpikeGoogleApiTests
{
    public class DistanceMatrixTests
    {
        [Fact]
        public void GetGarageDistances_Called_ReturnsDistanceForOne()
        {
            var distance = new DistanceMatrix();

            var response = distance.GetGarageDistances();

            Assert.NotNull(response);
        }
    }
}
