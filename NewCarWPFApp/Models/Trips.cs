using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace NewCarWPFApp.Models
{
    public class Trip
    {
        public string LicensePlate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Distance { get; set; }

        public Trip() { } // <- gør den parameterløs


        public Trip(string licensePlate, DateTime startDate, DateTime endDate, double distance)
        {
            LicensePlate = licensePlate;            
            StartDate = startDate;
            EndDate = endDate;
            Distance = distance;
            
        }

        public override string ToString()
        {
            return $"{LicensePlate};{StartDate:yyyy-MM-dd};{EndDate:yyyy-MM-dd};{Distance}";
        }

        public static Trip FromString(string input)
        {
            var parts = input.Split(';');
            if (parts.Length != 4)
            {
                throw new FormatException("Input string er ikke i det rigtige format til Trip.");
            }

            return new Trip(
                parts[0],                   //LicensePlate
                DateTime.Parse(parts[1]),   //StartDate
                DateTime.Parse(parts[2]),   //EndDate
                double.Parse(parts[3])     //Distance


                );

        }

    }
}
