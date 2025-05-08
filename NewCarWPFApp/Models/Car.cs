using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace NewCarWPFApp.Models
{
    public class Car
    {
        public string? Model { get; set; }
        public string? LicensePlate { get; set; }

        public Car() { }

        public Car(string model, string licensePlate)
        {
            
            Model = model;
            
            LicensePlate = licensePlate;
           
        }

        public override string ToString()
        {
            return $"{Model};{LicensePlate}";
        }

        public static Car FromString(string input)
        {
            var parts = input.Split(';');
            if (parts.Length != 2)
                throw new FormatException("Input string er ikke i korrekt format til Car.");

            return new Car(
                parts[0],
                parts[1]);
        }
    }
}
