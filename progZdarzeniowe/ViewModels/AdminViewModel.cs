using Caliburn.Micro;
using progZdarzeniowe.DataAccess;
using progZdarzeniowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace progZdarzeniowe.ViewModels
{
    class AdminViewModel : Screen
    {
        public List<Flight> allFlights { get; set; }
        
        public AdminViewModel()
        {
            getFlightsAsync();
        }

        private async Task getFlightsAsync()
        {
            //flightsAreFetching = true;
            allFlights = await Task.Run(() => Database.Session.Query<Flight>().ToList());
            //flightsAreFetching = false;
            //NotifyOfPropertyChange(() => flightsAreFetching);
        }

        public void updateFlights(DataGridRowEditEndingEventArgs e)
        {
            Flight flight = e.Row.Item as Flight;
            if (e.EditAction == DataGridEditAction.Commit)
            {
                flight.date = Regex.Replace(flight.date, @"[\s].*", "");
                Database.add(flight);
           }
        }
        public void addFlight(AddingNewItemEventArgs e)
        {
            Flight flight = e.NewItem as Flight;
            Database.add(flight);            
        }


        public async Task deleteFlight(Flight flight)
        {
            if (flight == null) return;
            await Database.remove(flight);
            await getFlightsAsync();
            NotifyOfPropertyChange(() => allFlights);
        }
    }
}
