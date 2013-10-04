using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.DAL;
using MDPOSDemo.Model;
using NUnit.Framework;

namespace MDPOSDemo.DAL_Tests
{
    [TestFixture]
    public class LoginData_Tests
    {
        private LoginData _target; 

        [SetUp]
        public void SetUp()
        {
            _target = new LoginData();
        }

        [TestCase("TestUser1", "passw0rd")]
        public void Login_ReturnsNameForAuthentication_Test(string userName, string authToken)
        {
            var request = BuildLoginRequest(userName, authToken);
            var actual = _target.Login(request);
            Assert.AreEqual(request.Username, actual.Value.Name);
        }

        [TestCase("TestUser1", "passw0rd")]
        public void Login_ReturnsMerchantKeyForAuthentication_Test(string userMerchantKey, string authToken)
        {
            var request = BuildLoginRequest(userMerchantKey, authToken);
            var actual = _target.Login(request);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(actual.Value.MerchantKey));
        }

        [TestCase("TestUser1", "passw0rd")]
        public void Login_ReturnsMerchantNameNameForAuthentication_Test(string userName, string authToken)
        {
            var request = BuildLoginRequest(userName, authToken);
            var actual = _target.Login(request);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(actual.Value.MerchantName));
        }

        [TestCase("TestUser1", "BADPASSWORD")]
        public void Login_ReturnsErrorForFailedAuthentication_Test(string username, string authToken)
        {
            var request = BuildLoginRequest(username, authToken);
            var actual = _target.Login(request);
            Assert.IsTrue(actual.Errors.Any());
        }


        private LoginRequest BuildLoginRequest(string username, string password)
        {
            return new LoginRequest() {Username = username, Password = password};
        }
    }
}
