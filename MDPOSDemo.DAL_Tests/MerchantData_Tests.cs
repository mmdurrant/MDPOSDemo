using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.DAL;
using NUnit.Framework;

namespace MDPOSDemo.DAL_Tests
{
    [TestFixture]
    public class MerchantData_Tests
    {
        private MerchantData _target;

        [SetUp]
        public void SetUp()
        {
            _target = new MerchantData();
        }

        [TestCase("TestUser1")]
        public void UpdateConfiguration_UpdatesConfiguration_Test(string username)
        {
            var configurationId = Guid.NewGuid().ToString();
            var actual = _target.UpdateConfigurationId(username, configurationId);
            Assert.IsFalse(actual.Errors.Any());
            Assert.AreNotEqual(0, actual.Value);
        }
    }
}
