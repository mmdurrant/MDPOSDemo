using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.Model;

namespace MDPOSDemo.BIZ.Extenders
{
    public static class LoginExtenders
    {
        public static UserSession AsUserSession(this LoginResult input)
        {
            var result = new UserSession();
            if (input != null)
            {
                result = new UserSession()
                {
                    Name = input.Name,
                    ID = input.ID,
                    ConfigurationID = input.ConfigurationID,
                    MerchantKey = input.MerchantKey,
                    MerchantName = input.MerchantName
                };
            }
            return result;
        }

        public static LoginRequest AsLoginRequest(this UserSession input)
        {
            var result = new LoginRequest();

            if (input != null)
            {
                result = new LoginRequest()
                {
                    Username = input.Name,
                    Password = input.Password,
                };
            }

            return result;
        }
    }
}
