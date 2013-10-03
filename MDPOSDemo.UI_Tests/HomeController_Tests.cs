using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MDPOSDemo.BIZ.Contracts;
using MDPOSDemo.BIZ.Extenders;
using MDPOSDemo.CC;
using MDPOSDemo.Model;
using MDPOSDemo.UI.Controllers;
using MDPOSDemo.UI.Models;
using Moq;
using MvcContrib.TestHelper;
using NUnit.Framework;

namespace MDPOSDemo.UI_Tests
{
    [TestFixture]
    public class HomeController_Tests
    {
        private HomeController _target;
        private Mock<ILoginBiz> _loginBizMock;
        private TestControllerBuilder _builder;
        private const string _validLoginName = "validuser";
        private const string _validLoginPassword = "validpassword";
        private Result<LoginResult> _validLoginResult;
        private Result<LoginResult> _invalidLoginResult;

        [SetUp]
        public void SetUp()
        {
            _builder = new TestControllerBuilder();
            _target = new HomeController();

            _builder.InitializeController(_target);


            _validLoginResult = BuildValidLoginResult();
            _invalidLoginResult = BuildInvalidLoginResult();

            _loginBizMock = new Mock<ILoginBiz>();
            _loginBizMock.Setup(x => x.Login(It.IsAny<LoginRequest>())).Returns(new Result<LoginResult>());
            _target.LoginRequestsInterface = _loginBizMock.Object;
        }

        [Test]
        public void Index_DefaultDirectsToLoginScreen_Test()
        {
            var expected = "Login";
            var actual = _target.Index() as ViewResult;
            Assert.AreEqual(expected, actual.ViewName);
        }

        [Test]
        public void Index_RedirectsToLoginIfNoSessionState_Test()
        {
            var expected = "Login";
            var actual = _target.Index() as ViewResult;
            Assert.AreEqual(expected, actual.ViewName);
        }

        [Test]
        public void Index_RedirectsToLoginIfCredentialsAreInvalid_Test()
        {
            var expected = "Login";
            SetupBizForInvalidLogin();
            var invalidLoginResult = BuildInvalidLoginResult();
            var userSession = invalidLoginResult.Value.AsUserSession();
            _builder.Session["UserSession"] = userSession;
            var actual = _target.Index() as ViewResult;
            Assert.AreEqual(expected, actual.ViewName);
        }

        [Test]
        public void Index_RedirectsToAppIfSessionStateIsValid_Test()
        {
            var expected = "POSApp";
            var validLoginResult = BuildValidLoginResult();
            var userSession = validLoginResult.Value.AsUserSession();
            _builder.Session["UserSession"] = userSession;
            var actual = _target.Index() as ViewResult;
            Assert.AreEqual(expected, actual.ViewName);
        }

        #region Helper methods
        private Result<LoginResult> BuildInvalidLoginResult()
        {
            return new Result<LoginResult>()
            {
                Value = new LoginResult()
                {
                    Name = string.Empty
                },
                Errors = new List<Error>()
                {
                    new Error("Invalid login")
                }
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
                new LoginResult()
                {
                    ConfigurationID = Guid.NewGuid().ToString(),
                    ID = 42,
                    MerchantKey = Guid.NewGuid().ToString(),
                    MerchantName = "ABC Mercantile",
                    Name = _validLoginName
                }
            };
        }

        private void SetupBizForValidLogin()
        {
            _loginBizMock.Setup(
                x =>
                    x.Login(
                        It.Is<LoginRequest>(
                            req => req.Name.Equals(_validLoginName, StringComparison.InvariantCultureIgnoreCase) && req.Password.Equals(_validLoginPassword))))
                .Returns(_validLoginResult);

        }

        private void SetupBizForInvalidLogin()
        {
            _loginBizMock.Setup(
                x =>
                    x.Login(
                        It.Is<LoginRequest>(
                            req => req == null || string.IsNullOrWhiteSpace(req.Name) || string.IsNullOrWhiteSpace(req.Password) || !req.Name.Equals(_validLoginName, StringComparison.InvariantCultureIgnoreCase) && !req.Password.Equals(_validLoginPassword))))
                .Returns(_invalidLoginResult);

        }
        #endregion

        
    }
}
