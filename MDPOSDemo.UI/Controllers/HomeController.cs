using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MDPOSDemo.BIZ.Contracts;

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
            return View();
        }

    }
}
