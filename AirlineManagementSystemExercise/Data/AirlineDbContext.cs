using AirlineManagementSystemExercise.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineManagementSystemExercise.Data
{
    public class AirlineDbContext : DbContext
    {
        public AirlineDbContext() : base("name=default")
        {

        }

        //public DbSet<Airline> Airlines { get; set; }
        //public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightCapacity> FlightCapacities { get; set; }//
        //public DbSet<Flight> FlightClasses { get; set; }
        //public DbSet<Flight> FlightSchedules { get; set; }
        //public DbSet<Flight> FlightRoutes { get; set; }//
        public DbSet<Flight> FlightCosts { get; set; }
        //public DbSet<Flight> Routes { get; set; }
        //public DbSet<Flight> Cities { get; set; }
        //public DbSet<Flight> Countries { get; set; }
    }
}
