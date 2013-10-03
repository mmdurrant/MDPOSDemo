using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.BIZ.Contracts;
using MDPOSDemo.CC;
using MDPOSDemo.DAL;
using MDPOSDemo.DAL.Contracts;
using MDPOSDemo.Model;

namespace MDPOSDemo.BIZ
{
    public class LoginBiz : ILoginBiz
    {
        private ILoginData _loginDataInterface;
        public ILoginData LoginDataInterface
        {
            get { return _loginDataInterface ?? (_loginDataInterface = Factories.DALFactory.GetLoginDataInterface()); }
            set { _loginDataInterface = value; }
        }

        public Result<LoginResult> Login(LoginRequest loginRequest)
        {
            return LoginDataInterface.Login(loginRequest);
        }
    }
}
