using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.DAL;
using MDPOSDemo.DAL.Contracts;

namespace MDPOSDemo.BIZ.Factories
{
    public class DALFactory
    {
        public static ILoginData GetLoginDataInterface()
        {
            return new LoginData();
        }
    }
}
