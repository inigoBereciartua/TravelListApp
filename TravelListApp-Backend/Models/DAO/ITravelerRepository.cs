﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelListApp_Backend.Models.DAO
{
    public interface ITravelerRepository
    {
        void addItem(Traveler traveler);
        void removeItem(Traveler traveler);
        ICollection<Traveler> getAllItems();

        Traveler getTraveler(ApplicationUser applicationUser);
        void updateItem(Traveler user);

        void SaveChanges();
    }
}
