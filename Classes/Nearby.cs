namespace Food_Truck_API
{
    public class Nearby
    {
        private IEnumerable<FoodTruck>? FoodTrucks;
        private readonly int N = 5;
        private static readonly string CSV_PATH = "<path_to_input_csv>";

        public Nearby()
        {
            FoodTrucks = ReadCsv();
        }
        
        private IEnumerable<FoodTruck>? ReadCsv()
        {
            var Lines = File.ReadAllLines(CSV_PATH)
                                           .Skip(1)
                                           .Select(v => FoodTruck.FromCsv(v, 0));
            if (Lines == null)
                return new List<FoodTruck>();
            else
                return Lines.ToList();
        }

        public IEnumerable<FoodTruck> GetNearestFoodTrucks(double longtitude, double latitude)
        {
            var resultFoodTrucks = new List<FoodTruck>();
            
            var coordinate = new Coordinate(latitude, longtitude);
            var maxHeap = new PriorityQueue<FoodTruck, double>();
            foreach (var foodTruck in FoodTrucks)
            {
                var distance = DistanceTo(coordinate, foodTruck.Coordinate);
                maxHeap.Enqueue(foodTruck, -distance);
                if (maxHeap.Count > N)                
                    maxHeap.Dequeue();
            }

            //Now dequeue n minimum ones
            for(var i = 0; i < N && maxHeap.Count > 0; i++)
                resultFoodTrucks.Add( maxHeap.Dequeue() );

            return resultFoodTrucks;
        }

        private double DistanceTo(Coordinate baseCoordinates, Coordinate targetCoordinates)
        {
            var baseRad = Math.PI * baseCoordinates.Latitude / 180;
            var targetRad = Math.PI * targetCoordinates.Latitude / 180;
            var theta = baseCoordinates.Longitude - targetCoordinates.Longitude;
            var thetaRad = Math.PI * theta / 180;

            double dist =
                Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
                Math.Cos(targetRad) * Math.Cos(thetaRad);
            dist = Math.Acos(dist);

            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return dist;
        }
    }
}
