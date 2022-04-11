## Food Truck Challenge

### What is the problem statement

If you are ever in San Francisco and want to try out the food trucks around, this Web API can come to your rescue.
It gives you nearest 5 food trucks for given longitude/latitude passed in.

I am using San Francisco's food truck open dataset which is publicly available is located [here](https://data.sfgov.org/Economy-and-Community/Mobile-Food-Facility-Permit/rqzj-sfat/data) and there is an endpoint with a CSV dump of the latest data [here](https://data.sfgov.org/api/views/rqzj-sfat/rows.csv).

To know more about the challenge, you can [read here](https://github.com/timfpark/take-home-engineering-challenge).
 
### How I approached this problem
- As part of my last role, I have worked on adding REST APIs. However I have not created Web API project from scratch. I took this challenge to learn how to set up one. 
  - I created a Microsoft ASP.Net Web API and which I hosted locally. Creating a templated project allowed me start with a sample working Web API which was great.   
  - The Web API which I envisaged would take in latitude/longitude as inputs and return JSON of nearest 5 food trucks.
  - 
    https://localhost:7084/FoodTruck/GetFoodTrucks POST API with request schema as below:
    ```json
    {
      "Latitude": 0,
      "Longitude": 0
    }
    ```
- Coming to the algo to get nearest 5 food trucks for given longitude/latitude, here is how I approached the problem
    - Firstly parse the csv and for each line instantiate an object depicting a food truck with properties like name, longitude, latitude, items served, etc    -
    - Use Priority Queue of size k(=5) as a max heap to store the closest k food trucks. Negative of distance between target coordinate and food truck is the priority
    - Now iterate over each food truck and add it priority queue. When the priority queue count becomes > k, then dequeue the farthest truck from the queue
    - At the end of iteration, dequeue the nearest food trucks and return
    - I added a simple XUnit Test to test the sanity of this algo function
    
- Now for the test run outputs

    **Input**
    
    
    POST https://localhost:7084/FoodTruck/GetFoodTrucks
    ```json
    {
    "Longitude" : -122.4273064,
    "Latitude" : 37.7620192
    }
    ```
    **Output**
    ```json
    {
      {
        " LocationId": 1571753,
        "Name": "The Geez Freeze",
        "FacilityType": "Truck",
        "LocationDescription": "18TH ST: DOLORES ST to CHURCH ST (3700 - 3799)",
        "Address": "3750 18TH ST",
        "Block": "3579",
        "Lot": "006",
        "Permit": "21MFF-00015",
        "Status": "APPROVED",
        "FoodItems": "Snow Cones: Soft Serve Ice Cream & Frozen Virgin Daiquiris",
        "Latitude": 37.76201920035647,
        "Longitude": -122.42730642251331,
        "Schedule": "http://bsm.sfdpw.org/PermitsTracker/reports/report.aspx?title=schedule&report=rptSchedule&params=permit=21MFF-00015&ExportPDF=1&Filename=21MFF-00015_schedule.pdf",
        "Dayshours": "",
        "Approved": "01/28/2022 12:00:00 AM",
        "Coordinate": {
          "Latitude": 37.76201920035647,
          "Longitude": -122.42730642251331
        }
      },
      {
          "LocationId": 1577179,
          "Name": "BH & MT LLC",
          "FacilityType": "Truck",
          "LocationDescription": "16TH ST: SPENCER ST to DOLORES ST (3220 - 3299)",
          "Address": "3253 16TH ST",
          "Block": "3567",
          "Lot": "039",
          "Permit": "21MFF-00128",
          "Status": "APPROVED",
          "FoodItems": "Cold Truck: Breakfast: Sandwiches: Salads: Pre-Packaged Snacks: Beverages",
          "Latitude": 37.764459521442355,
          "Longitude": -122.42516137635808,
          "Schedule": "http://bsm.sfdpw.org/PermitsTracker/reports/report.aspx?title=schedule&report=rptSchedule&params=permit=21MFF-00128&ExportPDF=1&Filename=21MFF-00128_schedule.pdf",
          "Dayshours": "",
          "Approved": "12/03/2021 12:00:00 AM",
          "Coordinate": {
            "Latitude": 37.764459521442355,
            "Longitude": -122.42516137635808
          }
        },
      {
          "LocationId": 1174530,
          "Name": "CC Acquisition LLC",
          "FacilityType": "Push Cart",
          "LocationDescription": "VALENCIA ST: 16TH ST to 17TH ST (500 - 599)",
          "Address": "560 VALENCIA ST",
          "Block": "3568",
          "Lot": "009",
          "Permit": "18MFF-0034",
          "Status": "REQUESTED",
          "FoodItems": "Chai Tea",
          "Latitude": 37.763858081360304,
          "Longitude": -122.4220826209929,
          "Schedule": "http://bsm.sfdpw.org/PermitsTracker/reports/report.aspx?title=schedule&report=rptSchedule&params=permit=18MFF-0034&ExportPDF=1&Filename=18MFF-0034_schedule.pdf",
          "Dayshours": "Sa-Su:9AM-4PM",
          "Approved": "",
          "Coordinate": {
            "Latitude": 37.763858081360304,
            "Longitude": -122.4220826209929
          }
        },
      {
          "LocationId": 1577180,
          "Name": "BH & MT LLC",
          "FacilityType": "Truck",
          "LocationDescription": "MARKET ST: CHURCH ST to 15TH ST (2101 - 2195) -- SOUTH --",
          "Address": "2145 MARKET ST",
          "Block": "3543",
          "Lot": "003B",
          "Permit": "21MFF-00128",
          "Status": "APPROVED",
          "FoodItems": "Cold Truck: Breakfast: Sandwiches: Salads: Pre-Packaged Snacks: Beverages",
          "Latitude": 37.7666247727157,
          "Longitude": -122.42951117634738,
          "Schedule": "http://bsm.sfdpw.org/PermitsTracker/reports/report.aspx?title=schedule&report=rptSchedule&params=permit=21MFF-00128&ExportPDF=1&Filename=21MFF-00128_schedule.pdf",
          "Dayshours": "",
          "Approved": "12/03/2021 12:00:00 AM",
          "Coordinate": {
            "Latitude": 37.7666247727157,
            "Longitude": -122.42951117634738
          }
        },
      {
          "LocationId": 1576238,
          "Name": "Natan's Catering",
          "FacilityType": "Truck",
          "LocationDescription": "17TH ST: MISSION ST to HOFF ST (3300 - 3343)",
          "Address": "3335 17TH ST",
          "Block": "3576",
          "Lot": "086",
          "Permit": "21MFF-00118",
          "Status": "APPROVED",
          "FoodItems": "Burgers: melts: hot dogs: burritos:sandwiches: fries: onion rings: drinks",
          "Latitude": 37.76315639322651,
          "Longitude": -122.42032223152648,
          "Schedule": "http://bsm.sfdpw.org/PermitsTracker/reports/report.aspx?title=schedule&report=rptSchedule&params=permit=21MFF-00118&ExportPDF=1&Filename=21MFF-00118_schedule.pdf",
          "Dayshours": "",
          "Approved": "12/16/2021 12:00:00 AM",
          "Coordinate": {
            "Latitude": 37.76315639322651,
            "Longitude": -122.42032223152648
          }
        }
    }
    ```
### What would I would have done if I had more time
I would have liked to create a front end which would consume this web api to help visualise the food trucks near by, as the target coordinate moved. 
