using Caliburn.Micro;
using NHibernate;
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
        private ISession flightsSession;
        public List<Flight> allFlights { get; set; }
        public bool gridVisible { get; set; } = false;
        public bool gridLoading { get; set; } = true;
        public AdminViewModel()
        {
            getFlightsAsync();
        }

        private async Task getFlightsAsync()
        {
            flightsSession = Database.newSession();
            gridVisible = false;
            gridLoading = true;
            NotifyOfPropertyChange(() => gridVisible);
            NotifyOfPropertyChange(() => gridLoading);
            allFlights = await Task.Run(() => flightsSession.Query<Flight>().ToList());
            gridVisible = true;
            gridLoading = false;
            NotifyOfPropertyChange(() => allFlights);
            NotifyOfPropertyChange(() => gridVisible);
            NotifyOfPropertyChange(() => gridLoading);
        }

        public void updateFlights(DataGridRowEditEndingEventArgs e)
        {
            Flight flight = e.Row.Item as Flight;
            if (e.EditAction == DataGridEditAction.Commit)
            {
                if (flight.date != null)
                {
                    flight.date = Regex.Replace(flight.date, @"[\s].*", "");
                }
                Database.add(flight, flightsSession);
           }
        }
        public void addFlight(AddingNewItemEventArgs e)
        {
            Flight flight = e.NewItem as Flight;
            Database.add(flight, flightsSession);            
        }


        public async Task deleteFlight(Flight flight)
        {
            if (flight == null) return;
            await Database.remove(flight, flightsSession);
            await getFlightsAsync();
            NotifyOfPropertyChange(() => allFlights);
        }
    }
}
