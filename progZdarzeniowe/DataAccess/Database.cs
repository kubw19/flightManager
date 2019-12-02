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

        private static ISessionFactory sessionFactory;

        public static ISession Session { get; set; }

        public static void OpenSession()
        {
            configuration = new Configuration();
            configuration.Configure();
            sessionFactory = configuration.BuildSessionFactory();
            Session = sessionFactory.OpenSession();
        }

        public static ISession newSession()
        {
            return sessionFactory.OpenSession();
        }

        public static void add(object obj, ISession session = null)
        {
            if (session == null)
            {
                Database.Session.Save(obj);
                Database.Session.Flush();
            }
            else
            {
                session.SaveOrUpdate(obj);
                session.Flush();
            }
        }

        public static async Task remove(object obj, ISession session = null)
        {
            if (session == null)
            {
                Database.Session.Delete(obj);
                Database.Session.Flush();
            }
            else
            {
                session.Delete(obj);
                session.Flush();
            }
        }

    }
}