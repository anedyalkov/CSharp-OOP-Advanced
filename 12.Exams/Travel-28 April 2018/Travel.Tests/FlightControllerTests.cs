// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING
using Travel.Core.Controllers;
using Travel.Entities;
using Travel.Entities.Airplanes;
using Travel.Entities.Airplanes.Contracts;
using Travel.Entities.Items;
namespace Travel.Tests
{
	using NUnit.Framework;
    using System.Collections.Generic;
   

    [TestFixture]
    public class FlightControllerTests
    {
        [Test]
        public void TestAirplaneIsOverBookedAndThereIsConfiscatedBaggage()
        {
            var airport = new Airport();
            var flightController = new FlightController(airport);
            var airplane = new LightAirplane();
            var trip = new Trip("Sofia", "Plovdiv", airplane);
            airport.AddTrip(trip);
            var passenger1 = new Passenger("Pesho");
            airplane.AddPassenger(passenger1);
            var passenger2 = new Passenger("Gogo");
            airplane.AddPassenger(passenger2);
            var passenger3 = new Passenger("Miro");
            airplane.AddPassenger(passenger3);
            var passenger4 = new Passenger("Niki");
            airplane.AddPassenger(passenger4);
            var passenger5 = new Passenger("Lili");
            airplane.AddPassenger(passenger5);
            var passenger6 = new Passenger("Nadia");
            airplane.AddPassenger(passenger6);

            var items = new List<Item>();
            var item1 = new Laptop();
            var item2 = new Jewelery();
            var item3 = new TravelKit();
            var item4 = new Toothbrush();
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            items.Add(item4);

            var bag1 = new Bag(passenger1, items);
            var bag2 = new Bag(passenger2, items);
            var bag3 = new Bag(passenger3, items);
            var bag4 = new Bag(passenger4, items);
            var bag5 = new Bag(passenger5, items);
            passenger1.Bags.Add(bag1);
            passenger2.Bags.Add(bag2);
            passenger3.Bags.Add(bag3);
            passenger4.Bags.Add(bag4);
            passenger5.Bags.Add(bag5);

            var completedTrip = new Trip("Sofia", "Varna", new LightAirplane());
            completedTrip.Complete();

            airport.AddTrip(completedTrip);
            string expectedResult = "SofiaPlovdiv1:\r\nOverbooked! Ejected Gogo\r\nConfiscated 1 bags ($3333)\r\nSuccessfully transported 5 passengers from Sofia to Plovdiv.\r\nConfiscated bags: 1 (4 items) => $3333";
            string actualResult = flightController.TakeOff();
            //System.Console.WriteLine();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
            Assert.That(trip.IsCompleted, Is.True);
        }
    }
}
