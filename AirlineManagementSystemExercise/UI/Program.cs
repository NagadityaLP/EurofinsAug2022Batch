using AirlineManagementSystemExercise.Data;
using AirlineManagementSystemExercise.Entities;
using System;
using System.Collections.Generic;

namespace AirlineManagementSystemExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirlineDbContext db = new AirlineDbContext();
            //Airline airline = new Airline { AirlineCode = "123", AirlineID = 7890, AirlineLogo = "SpicejetLogo", AirlineName = "Spicejet", Country = "India" };
            //db.Airlines.Add(airline);
            //db.SaveChanges();
        }
    }
}
