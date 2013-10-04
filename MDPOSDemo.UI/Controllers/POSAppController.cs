using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MDPOSDemo.BIZ;
using MDPOSDemo.BIZ.Contracts;
using MDPOSDemo.Model;
using MDPOSDemo.UI.Models;

namespace MDPOSDemo.UI.Controllers
{
    public class POSAppController : Controller
    {
        private IMerchantBiz _merchantBizInterface;
        private UserSession _userSession;
        //
        // GET: /POSApp/

        public UserSession UserSession
        {
            get { return _userSession ?? (_userSession = Session["UserSession"] as UserSession); }
            set
            {
                _userSession = value;
                Session["UserSession"] = _userSession;
            }
        }

        public IMerchantBiz MerchantBizInterface
        {
            get { return _merchantBizInterface ?? (_merchantBizInterface = Factories.BIZFactory.GetMerchantBiz()); }
            set { _merchantBizInterface = value; }
        }

        public ActionResult Index()
        {
            var model = BuildMerchantInfoModelFromSession();
            if (model != null)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public JsonResult StoreConfigurationId(string configId)
        {
            var session = UserSession;
            var storeConfigResult = MerchantBizInterface.UpdateConfigurationId(session.Name, configId);

            return new JsonResult {Data = new {success = storeConfigResult.Value, errors = storeConfigResult.Errors}};
        }

        public MerchantInfoModel BuildMerchantInfoModelFromSession()
        {
            var result = default(MerchantInfoModel);
            
            if (UserSession != null)
            {
                result = new MerchantInfoModel();
                result.name = UserSession.Name;
                result.merchantKey = UserSession.MerchantKey;
                result.merchantName = UserSession.MerchantName;
                //TODO: This should be in an enum.
                result.transactionType = "CreditSale";
                result.configurationId = UserSession.ConfigurationID;
            }
            return result;
        }
    }
}
