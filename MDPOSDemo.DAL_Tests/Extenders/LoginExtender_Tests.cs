using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.DAL.Extenders;
using MDPOSDemo.DAL.POCOs;
using NUnit.Framework;

namespace MDPOSDemo.DAL_Tests.Extenders
{
    [TestFixture]
    public class LoginExtender_Tests
    {
        private POSUser _target;

        [SetUp]
        public void SetUp()
        {
            _target = BuildTestUser();
        }

        private POSUser BuildTestUser()
        {
            return new POSUser()
            {
                ID = 42,
                ConfigurationID = Guid.NewGuid().ToString(),
                MerchantKey = Guid.NewGuid().ToString(),
                MerchantName = "ABC Mercantile",
                Name = "abcmerc"
            };
        }

        [Test]
        public void AsLoginResult_ID_Test()
        {
            var actual = _target.AsLoginResult();
            Assert.AreEqual(_target.ID, actual.ID);
        }

        [Test]
        public void AsLoginResult_ConfigurationID_Test()
        {
            var actual = _target.AsLoginResult();
            Assert.AreEqual(_target.ConfigurationID, actual.ConfigurationID);
        }

        [Test]
        public void AsLoginResult_MerchantKey_Test()
        {
            var actual = _target.AsLoginResult();
            Assert.AreEqual(_target.MerchantKey, actual.MerchantKey);
        }

        [Test]
        public void AsLoginResult_MerchantName_Test()
        {
            var actual = _target.AsLoginResult();
            Assert.AreEqual(_target.MerchantName, actual.MerchantName);
        }

        [Test]
        public void AsLoginResult_Name_Test()
        {
            var actual = _target.AsLoginResult();
            Assert.AreEqual(_target.Name, actual.Name);
        }
    }
}
