using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.CC;
using MDPOSDemo.CC.Extenders;
using MDPOSDemo.DAL.Contracts;
using MDPOSDemo.DAL.Extenders;
using MDPOSDemo.DAL.POCOs;
using MDPOSDemo.Model;

namespace MDPOSDemo.DAL
{
    public class LoginData : DataBase, ILoginData 
    {
        public LoginData()
        {
            ConnectionString = DbConnectionStrings.MDPOSDemoAzure;
        }

        public Result<LoginResult> Login(LoginRequest request)
        {
            var result = new Result<LoginResult>();

            //TODO: Replace with actual code
            var dbResult = Query<POSUser>(@"
                SELECT 
                    ID,
                    Name,
                    MerchantName,
                    MerchantKey,
                    ConfigurationID
                FROM POSUser
                WHERE Name = @name AND AuthenticationToken = @authToken", new { @name = request.Username, @authToken = request.Password });

            result.Errors.Add(dbResult.Errors);

            if (result.IsValid && dbResult.Value.Any())
            {
                result.Value = dbResult.Value.Select(x => x.AsLoginResult()).FirstOrDefault();
            }
            else
            {
                result.AddError("Could not authenticate user {0}", request.Username);
            }
            
            return result;
        }

    }

    
}
