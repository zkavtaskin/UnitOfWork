using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;

namespace UnitOfWork.Test
{
    [TestClass]
    public class UnitOfWorkTest
    {
        [TestMethod]
        public void NHConfigurationSingleton_SingleCall_ConfigurationIsReturned()
        {
            NHibernate.Cfg.Configuration config = NHConfigurationSingleton.Configuration;
            Assert.IsNotNull(config);
        }

        [TestMethod]
        public void NHConfigurationSingleton_SeveralCalls_ConfigurationIsReturned()
        {
            NHibernate.Cfg.Configuration config = NHConfigurationSingleton.Configuration;
            config = NHConfigurationSingleton.Configuration;
            Assert.IsNotNull(config);
        }

        [TestMethod]
        public void NHSessionFactorySingleton_SingleCall_SessionFactoryIsReturned()
        {
            ISessionFactory sessionFactory = NHSessionFactorySingleton.SessionFactory;
            Assert.IsNotNull(sessionFactory);
        }
    }
}
