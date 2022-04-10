namespace Food_Truck_API
{
    public class FoodTruck
    {
        public int LocationId { get; set; }

        public string? Name { get; set; }

        public string? FacilityType { get; set; }

        public string? LocationDescription { get; set; }

        public string? Address { get; set; }

        public string? Block { get; set; }

        public string? Lot { get; set; }

        public string? Permit { get; set; }

        public string? Status { get; set; }

        public string? FoodItems { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string? Schedule { get; set; }

        public string? Dayshours { get; set; }

        public string? Approved { get; set; }

        public Coordinate? Coordinate { get; set; }
        public static FoodTruck FromCsv(string csvLine, int v)
        {
            string[] values = csvLine.Split(',');
            var foodTruck = new FoodTruck();
            foodTruck.LocationId = int.Parse(values[0]);
            foodTruck.Name = values[1];
            foodTruck.FacilityType = values[2];
            foodTruck.LocationDescription = values[4];
            foodTruck.Address = values[5];
            foodTruck.Block = values[7];
            foodTruck.Lot = values[8];
            foodTruck.Permit = values[9];
            foodTruck.Status = values[10];
            foodTruck.FoodItems = values[11];
            foodTruck.Latitude = (values[14] != "" ) ? Convert.ToDouble(values[14]) : 0;
            foodTruck.Longitude = (values[15] != "") ? Convert.ToDouble(values[15]) : 0;
            foodTruck.Schedule = values[16];
            foodTruck.Dayshours = values[17];
            foodTruck.Approved = values[19];
            foodTruck.Coordinate = new Coordinate(foodTruck.Latitude, foodTruck.Longitude);
            return foodTruck;
        }
    }

}
