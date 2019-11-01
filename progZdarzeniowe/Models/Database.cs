using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Web;

namespace progZdarzeniowe.Models
{
    public class Database
    {
        private static Configuration configuration;
        private static ISession session;
        public static ISession Session { get => session; set => session = value; }

        public static void OpenSession()
        {
            configuration = new Configuration();
            configuration.Configure();
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            session = sessionFactory.OpenSession();
        }

    }
}