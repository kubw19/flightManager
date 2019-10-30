using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace progZdarzeniowe.ViewModels
{
    class MainViewModel : Conductor<object>
    {

        public MainViewModel()
        {
            ActivateItem(new BookFlightViewModel());
        }
    }
}
