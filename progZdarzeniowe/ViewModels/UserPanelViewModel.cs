﻿using progZdarzeniowe.DataAccess;
using progZdarzeniowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Caliburn.Micro;
using System.Transactions;

namespace progZdarzeniowe.ViewModels
{
    class UserPanelViewModel : Screen
    {
        public bool flightsAreFetching { get; private set; } = true;
        public bool flightOrdersAreFetching { get; private set; } = true;
        public List<Flight> flights { get; set; }
        public List<FlightOrder> flightOrders { get; set; }

        public UserPanelViewModel()
        {
            prepare();
        }

        private async Task prepare()
        {
            await getFlightsAsync();
            await getFlightOrdersAsync();
        }

        private async Task getFlightsAsync()
        {
            flightsAreFetching = true;
            flights = await Task.Run(() => Database.Session.Query<Flight>().ToList());
            NotifyOfPropertyChange(() => flights);
            flightsAreFetching = false;
            NotifyOfPropertyChange(() => flightsAreFetching);
        }

        private async Task getFlightOrdersAsync()
        {
            flightOrders = await Task.Run(() => Database.Session.Query<FlightOrder>().ToList());
            NotifyOfPropertyChange(() => flightOrders);
            flightOrdersAreFetching = false;
            NotifyOfPropertyChange(() => flightOrdersAreFetching);
        }

        public void bookFlight(Flight flight, string type)
        {
            var flightOrder = new FlightOrder();
            flightOrder.arrPlace = flight.arrPlace;
            flightOrder.arrTime = flight.arrTime;
            flightOrder.depPlace = flight.depPlace;
            flightOrder.depTime = flight.depTime;
            flightOrder.date = flight.date;
            flightOrder.flightNumber = flight.flightNumber;

            switch (type)
            {
                case "business":
                    flightOrder.price = flight.businessPrice;
                    break;
                default:
                    flightOrder.price = flight.economyPrice;
                    break;               

            }

            Database.add(flightOrder);
            getFlightOrdersAsync();

        }
        public void cancelFlight(FlightOrder flightOrder)
        {

            Database.remove(flightOrder);
            getFlightOrdersAsync();
        }
    }
}
