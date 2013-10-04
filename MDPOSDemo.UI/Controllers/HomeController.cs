using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MDPOSDemo.BIZ.Contracts;
using MDPOSDemo.BIZ.Extenders;
using MDPOSDemo.CC;
using MDPOSDemo.CC.Extenders;
using MDPOSDemo.Model;
using MDPOSDemo.UI.Models;

namespace MDPOSDemo.UI.Controllers
{
    public class HomeController : Controller
    {
        private ILoginBiz _loginRequestsInterface;
        public ILoginBiz LoginRequestsInterface
        {
            get { return _loginRequestsInterface ?? (_loginRequestsInterface = Factories.BIZFactory.GetLoginBiz()); }
            set { _loginRequestsInterface = value; }
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            var userSession = Session["UserSession"] as UserSession;

            if (userSession != null)
            {
                var loginRequest = userSession.AsLoginRequest();
                var loginResult = AuthenticateUser(loginRequest);

                if (!loginResult.IsValid)
                {
                    return View("Login", new LoginRequestModel() {Errors = loginResult.Errors});
                }

                return RedirectToAction("Index", "POSApp", loginResult);
            }
            else
            {
                return View("Login", new LoginRequestModel());
            }
        }


        // Login
        public ActionResult Login(LoginRequestModel model)
        {
            var loginRequest = BuildLoginRequestFromModel(model);
            var loginResult = AuthenticateUser(loginRequest);
            if (loginResult.IsValid)
            {
                Session["UserSession"] = loginResult.Value.AsUserSession();
                return RedirectToAction("Index", "POSApp");
            }
            else
            {
                model.Errors.Add(loginResult.Errors);
                return View("Login", model);
            }
        }

        public LoginRequest BuildLoginRequestFromModel(LoginRequestModel model)
        {
            return new LoginRequest()
            {
                Username = model.Username,
                Password = model.Password
            };
        }

        public Result<LoginResult> AuthenticateUser(LoginRequest request)
        {
            var loginResult = LoginRequestsInterface.Login(request);
            return loginResult;
        }
    }
}
