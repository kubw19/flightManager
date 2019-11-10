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

namespace progZdarzeniowe.ViewModels
{
    class MainViewModel : Conductor<object>
    {
        public MainViewModel()
        {
            Database.OpenSession();
            ActivateItem(new UserPanelViewModel());
        }

    }
}
