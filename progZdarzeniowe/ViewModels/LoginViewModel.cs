using Caliburn.Micro;
using progZdarzeniowe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace progZdarzeniowe.ViewModels
{
    class LoginViewModel : Screen
    {
        private IEventAggregator _Events;
        public LoginViewModel(IEventAggregator events)
        {
            _Events = events;
        }
        public void emailClick(TextBox email)
        {
            email.Text = "";
        }
        public void emailLeave(TextBox email)
        {
            if (email.Text == "") email.Text = "Email";
        }

        public void passwordClick(TextBox password)
        {
            password.Text = "";
        }
        public void passwordLeave(TextBox password)
        {
            if (password.Text == "") password.Text = "Password";
        }

        public void loginButton()
        {
            _Events.PublishOnUIThread(new ComEvent("loggedAdmin"));
        }
    }
}
