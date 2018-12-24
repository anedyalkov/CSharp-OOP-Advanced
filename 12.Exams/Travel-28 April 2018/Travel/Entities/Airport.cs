namespace Travel.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	
	public class Airport : IAirport
	{
		private List<IBag> confiscatedBags;
		private List<IBag> checkedInBags;
		private List<ITrip> trips;
		private List<IPassenger> persons;

        public Airport()
        {
            confiscatedBags = new List<IBag>();
            checkedInBags = new List<IBag>();
            trips = new List<ITrip>();
            persons = new List<IPassenger>();
        }

        public IReadOnlyCollection<IBag> CheckedInBags => checkedInBags.AsReadOnly();

        public IReadOnlyCollection<IBag> ConfiscatedBags => confiscatedBags.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => persons.AsReadOnly();

        public IReadOnlyCollection<ITrip> Trips => trips.AsReadOnly();

        public IPassenger GetPassenger(string username) => persons.FirstOrDefault(p => p.Username == username);

		public ITrip GetTrip(string id) => trips.FirstOrDefault(t => t.Id == id);

        public void AddPassenger(IPassenger passenger) => persons.Add(passenger);

        public void AddTrip(ITrip trip) => trips.Add(trip);

        public void AddCheckedBag(IBag bag) => checkedInBags.Add(bag);

        public void AddConfiscatedBag(IBag bag) => confiscatedBags.Add(bag);
	}
}