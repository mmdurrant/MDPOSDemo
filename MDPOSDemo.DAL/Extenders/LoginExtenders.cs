using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.DAL.POCOs;
using MDPOSDemo.Model;

namespace MDPOSDemo.DAL.Extenders
{
    public static class LoginExtenders
    {
        public static LoginResult AsLoginResult(this POSUser input)
        {
            var result = new LoginResult();

            result.ID = input.ID;
            result.Name = input.Name;
            result.MerchantName = input.MerchantName;
            result.MerchantKey = input.MerchantKey;
            result.ConfigurationID = input.ConfigurationID;
            
            return result;
        }
    }
}
