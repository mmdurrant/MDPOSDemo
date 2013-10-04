using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MDPOSDemo.BIZ;
using MDPOSDemo.BIZ.Contracts;

namespace MDPOSDemo.UI.Factories
{
    public class BIZFactory
    {
        public static ILoginBiz GetLoginBiz()
        {
            return new LoginBiz();
        }

        public static IMerchantBiz GetMerchantBiz()
        {
            return new MerchantBiz();
        }
    }
}