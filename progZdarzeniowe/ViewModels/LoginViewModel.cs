using Caliburn.Micro;
using progZdarzeniowe.DataAccess;
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
        public bool loginIsProceeding { get; private set; } = false;
        public bool wrongCredentials { get; private set; } = false;
        public string email { get; set; } = "Email";
        public string password { get; set; } = "Password";
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
            getUserAsync();
        }

        private async Task getUserAsync()
        {
            loginIsProceeding = true;
            NotifyOfPropertyChange(() => loginIsProceeding);
            User user = await Task.Run(() => Database.Session.Query<User>().Where(x => x.email.Equals(email) && x.password.Equals(password)).SingleOrDefault());
            loginIsProceeding = false;
            NotifyOfPropertyChange(() => loginIsProceeding);
            if (user != null)
            {
                Session.currentUser = user;
                if (user.isAdmin)
                {
                    _Events.PublishOnUIThread(new ComEvent("loggedAdmin"));
                }
                else
                {
                    _Events.PublishOnUIThread(new ComEvent("loggedUser"));
                }
            }
            else
            {
                wrongCredentials = true;
                NotifyOfPropertyChange(() => wrongCredentials);

            }
        }
    }
}
