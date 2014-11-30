using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace UnitOfWork
{
    public static class NHSessionFactorySingleton
    {
        private static ISessionFactory sessionFactory = null;
        private static object lockObj = new object();

        public static ISessionFactory SessionFactory
        {
            get
            {
                lock (lockObj)
                {
                    if (sessionFactory == null)
                    {
                        sessionFactory = NHConfigurationSingleton.Configuration.BuildSessionFactory();
                    }
                }

                return sessionFactory;
            }
        }
    }
}
