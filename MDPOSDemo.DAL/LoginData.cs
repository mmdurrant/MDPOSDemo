using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.CC;
using MDPOSDemo.Contracts;
using MDPOSDemo.Model;

namespace MDPOSDemo.DAL
{
    public class LoginData : DataBase, ILoginData 
    {
        public Result<bool> Login(LoginRequest request)
        {
            var result = new Result<bool>();
            result.Value = false;



            //TODO: Replace with actual code
            if (request.Name.Equals("testuser") && request.Password.Equals("password"))
            {
                result.Value = true;
            }
            else
            {
                result.AddError("The requested username/password was invalid.");
            }

            return result;
        }
    }
}
