using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.BIZ;
using MDPOSDemo.CC;
using MDPOSDemo.DAL.Contracts;
using MDPOSDemo.Model;
using Moq;
using NUnit.Framework;

namespace MDPOSDemo.BIZ_Tests
{
    [TestFixture]
    public class LoginBiz_Unit_Tests
    {
        private LoginBiz _target;
        private Mock<ILoginData> _loginDataMock;
        private const string _validLoginName = "validuser";
        private const string _validLoginPassword = "validpassword";
        private Result<LoginResult> _validLoginResult;
        private Result<LoginResult> _invalidLoginResult;

        [SetUp]
        public void SetUp()
        {
            _target = new LoginBiz();
            _loginDataMock = new Mock<ILoginData>();
            _validLoginResult = BuildValidLoginResult();
            _invalidLoginResult = BuildInvalidLoginResult();
            _loginDataMock.Setup(
                x =>
                    x.Login(
                        It.Is<LoginRequest>(
                            request =>
                                request.Name.Equals("validuser", StringComparison.InvariantCulture) &&
                                request.Password.Equals("validpassword", StringComparison.InvariantCulture))))
                                .Returns(_validLoginResult);
            
            _loginDataMock.Setup(
                x =>
                    x.Login(
                        It.Is<LoginRequest>(
                            request =>
                                !request.Name.Equals(_validLoginName, StringComparison.InvariantCultureIgnoreCase) &&
                                !request.Password.Equals(_validLoginPassword))))
                                .Returns(_invalidLoginResult);
            
            _target.LoginDataInterface = _loginDataMock.Object;
        }

        [Test]
        public void Login_ValidLoginReturnsNoErrors_Test()
        {
            var request = BuildValidLoginRequest();
            var actual = _target.Login(request);
            Assert.IsTrue(actual.IsValid);
            Assert.AreEqual(request.Name, actual.Value.Name);
        }

        [Test]
        public void Login_InvalidLoginReturnsErrors_Test()
        {
            var request = BuildInvalidLoginRequest();
            var actual = _target.Login(request);
            Assert.IsFalse(actual.IsValid);
            Assert.IsTrue(actual.Errors.Any(x => x.Message == "Invalid login"));
        }

        #region Helper methods
        private Result<LoginResult> BuildInvalidLoginResult()
        {
            return new Result<LoginResult>()
            {
                Value = null,
                Errors = new List<Error>()
                {
                    new Error("Invalid login")
                }
            };
        }

        private LoginRequest BuildInvalidLoginRequest()
        {
            return new LoginRequest
            {
                Name = Guid.NewGuid().ToString(),
                Password = Guid.NewGuid().ToString()
            };
        }

        private LoginRequest BuildValidLoginRequest()
        {
            return new LoginRequest()
            {
                Name = _validLoginName,
                Password = _validLoginPassword
            };
        }

        private Result<LoginResult> BuildValidLoginResult()
        {
            return new Result<LoginResult>()
            {
                Value =
                new LoginResult() {
                    ConfigurationID = Guid.NewGuid().ToString(),
                    ID = 42,
                    MerchantKey = Guid.NewGuid().ToString(),
                    MerchantName = "ABC Mercantile",
                    Name = _validLoginName
                }
            };
        }
        #endregion
    }
}
