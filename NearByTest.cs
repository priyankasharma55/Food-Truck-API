using Xunit;
using Food_Truck_API;
using System.Collections.Generic;

namespace Food_Truck_API_Tests
{
    public class NearByTest
    {
        [Fact]
        public void Test_GetNearestFoodTrucks()
        {
            var longitude = -122.42730642251331;
            var latitude = 37.76201920035647;
            var nearby = new Nearby();

            var foodtrucks = (List<FoodTruck>)nearby.GetNearestFoodTrucks(longitude, latitude);
            Assert.NotNull(foodtrucks);
            Assert.Equal(longitude, foodtrucks[0].Longitude);
            Assert.Equal(latitude, foodtrucks[0].Latitude);

        }
    }
}