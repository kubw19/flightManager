using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace progZdarzeniowe.DataAccess
{
    public class Database
    {
        private static Configuration configuration;

        public static ISession Session { get; set; }

        public static void OpenSession()
        {
            configuration = new Configuration();
            configuration.Configure();
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            Session = sessionFactory.OpenSession();
        }

        public static void add(object obj)
        {
            Database.Session.Save(obj);
            Database.Session.Flush();
        }

        public static async Task remove(object obj)
        {
            Database.Session.Delete(obj);
            Database.Session.Flush();
        }

    }
}