﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models.DAO
{
    public interface ITravelItemRepository
    {
        void addTravelItem(TravelItem travelItem);
        void removeItem(TravelItem travelItem);
        ICollection<TravelItem> getTravelItemOnTravelId(int id);
        ICollection<TravelItem> getAllItems();
        void updateItem(TravelItem travelItem);
        void SaveChanges();
    }
}
