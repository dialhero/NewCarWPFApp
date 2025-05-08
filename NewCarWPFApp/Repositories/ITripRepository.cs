﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewCarWPFApp.Models;

namespace NewCarWPFApp.Repositories
{
    public interface ITripRepository
    {
        public List<Trip> GetTripsForCar(string licensePlate);

        public void AddTrip(Trip trip);

        public void DeleteTrip(Trip trip);

        
    }
}
