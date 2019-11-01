using progZdarzeniowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progZdarzeniowe.ViewModels
{
    class BookFlightViewModel
    {
        public List<Flight> flights { get; set; }
        public BookFlightViewModel()
        {
            flights = Database.Session.Query<Flight>().ToList();
        }
    }
}
