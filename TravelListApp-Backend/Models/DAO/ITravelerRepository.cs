using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelListApp_Backend.Models.DAO
{
    public interface ITravelerRepository
    {
        void addTraveler(Traveler traveler);
        void removeTraveler(Traveler traveler);
        ICollection<Traveler> getAllItems();

        Traveler getTraveler(ApplicationUser applicationUser);
        void updateTraveler(Traveler user);

        void SaveChanges();
    }
}
