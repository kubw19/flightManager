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
    class MainViewModel : Conductor<object>, IHandle<ComEvent>
    {
        public bool bookFlightButtonEnabled { get; set; } = false;
        public bool manageFlightsButtonEnabled { get; set; } = false;

        private IEventAggregator _Events;

        public MainViewModel(IEventAggregator events)
        {
            _Events = events;
            Database.OpenSession();
            ActivateItem(new LoginViewModel(_Events));
            _Events.Subscribe(this);
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
            ActivateItem(new LoginViewModel(_Events));
        }

        public void Handle(ComEvent message)
        {
            if (message.value == "loggedAdmin" || message.value == "loggedUser")
            {
                bookFlightButtonEnabled = true;
                manageFlightsButtonEnabled = true;
                NotifyOfPropertyChange(() => bookFlightButtonEnabled);
                NotifyOfPropertyChange(() => manageFlightsButtonEnabled);
                this.bookFlight();
            }
        }
    }
}
