using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.CC;
using MDPOSDemo.Model;

namespace MDPOSDemo.Contracts
{
    public interface ILoginData
    {
        Result<LoginResult> Login(LoginRequest request);
    }
}
