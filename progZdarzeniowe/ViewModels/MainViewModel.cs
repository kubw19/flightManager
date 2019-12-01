using Caliburn.Micro;
using NHibernate;
using NHibernate.Cfg;
using progZdarzeniowe.DataAccess;
using progZdarzeniowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace progZdarzeniowe.ViewModels
{
    class MainViewModel : Conductor<object>
    {
        private Button bookFlightButton { get; set; }
        private Button manageFlightsButton { get; set; }

        public void buttonInitialize(Button but, string id = "manageFlightsButton")
        {
            Console.WriteLine("asd");
            switch (id)
            {
                case "bookFlight":
                    this.bookFlightButton = but;
                    bookFlightButton.IsEnabled = false;
                    break;
                case "manageFlightsButton":
                    this.manageFlightsButton = but;
                    manageFlightsButton.IsEnabled = false;
                    break;
            }
        }

        public MainViewModel()
        {
            Database.OpenSession();
            ActivateItem(new LoginViewModel());
        }

        public void manageFlights()
        {
            ActivateItem(new AdminViewModel());
        }

        public void bookFlight()
        {
            ActivateItem(new UserPanelViewModel());
        }

        public void login()
        {
            ActivateItem(new LoginViewModel());
        }
        
    }
}
