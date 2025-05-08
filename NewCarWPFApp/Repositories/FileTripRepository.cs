﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NewCarWPFApp.Models;

namespace NewCarWPFApp.Repositories
{
    
        public class FileTripRepository : ITripRepository
        {
            public string FilePath { get; set; }

            public FileTripRepository(string filePath)
            {
                FilePath = filePath;
            }

            public List<Trip> GetTripsForCar(string licensePlate)      //Henter alle trips for en bestemt bil
            {
                var trips = new List<Trip>();

                if (!File.Exists(FilePath))
                    return trips; //Returnerer tom liste hvis filen ikke findes

                foreach (var line in File.ReadAllLines(FilePath))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var trip = Trip.FromString(line);
                        if (trip.LicensePlate.Equals(licensePlate, StringComparison.OrdinalIgnoreCase))
                        {
                            trips.Add(trip);
                        }
                    }
                }

                return trips;
            }

            public void AddTrip(Trip trip)     //Tilføjer en ny tur til filen
            {
                using (var sw = File.AppendText(FilePath))
                {
                    sw.WriteLine(trip);
                }
            }


            public void DeleteTrip(Trip trip)   //Sletter en specifik tur (baseret på bil, dato og starttidspunkt)
            {
                var allTrips = GetAllTrips();
                var tripToRemove = allTrips.FirstOrDefault(t =>
                t.LicensePlate.Equals(trip.LicensePlate, StringComparison.OrdinalIgnoreCase) &&
                t.StartDate == trip.StartDate &&
                t.EndDate == trip.EndDate);

                if (tripToRemove != null)
                {
                    allTrips.Remove(tripToRemove);
                    SaveAllTrips(allTrips);
                }
            }

            private List<Trip> GetAllTrips()    //Privat hjælpemetode – læser ALLE trips
            {
                var trips = new List<Trip>();

                if (!File.Exists(FilePath))
                { return trips; }

                foreach (var line in File.ReadAllLines(FilePath))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        trips.Add(Trip.FromString(line));
                    }
                }
                return trips;
            }

            private void SaveAllTrips(List<Trip> trips)     //Privat hjælpemetode – overskriver filen med ny trip-liste
            {
                using (var sw = new StreamWriter(FilePath, false))
                {
                    foreach (var trip in trips)
                    {
                        sw.WriteLine(trip.ToString());
                    }
                }
            }

        }
    }


