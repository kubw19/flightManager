using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NHibernate;
using NHibernate.Cfg;

namespace progZdarzeniowe
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Configuration myConfiguration;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

        public MainWindow()
        {
            InitializeComponent();
                
            // sprawdzamy czy przy uruchamianiu aplikacje sesje są otwarte
            // jeżeli tak należy je zamknąć
            if (mySession != null && mySession.IsOpen)
            {
                mySession.Close();
            }
            if (mySessionFactory != null && !mySessionFactory.IsClosed)
            {
                mySessionFactory.Close();
            }
            // Inicjowanie NHibernate
            myConfiguration = new Configuration();
            myConfiguration.Configure();
            mySessionFactory = myConfiguration.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();
            // Przygotowanie przykładowanych danych

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Domain.Flight flight = new Domain.Flight();
            flight.arrPlace = "2";
            flight.depPlace = "3";


            using (mySession.BeginTransaction())
            {
                mySession.Save(flight);
                //pp.ItemsSource = mySession.QueryOver<Domain.Flight>().List();
                Console.WriteLine(mySession.QueryOver<Domain.Flight>().List());
                mySession.Transaction.Commit();
            }

            Domain.Flight[] flights = new Domain.Flight[2];
            flights[0] = flight;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
