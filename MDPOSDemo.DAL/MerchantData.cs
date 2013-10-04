using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.CC;
using MDPOSDemo.CC.Extenders;
using MDPOSDemo.DAL.Contracts;

namespace MDPOSDemo.DAL
{
    public class MerchantData : DataBase, IMerchantData
    {
        public MerchantData()
        {
            ConnectionString = DbConnectionStrings.MDPOSDemoAzure;
        }

        public Result<int> UpdateConfigurationId(string name, string configurationId)
        {
            var result = new Result<int>();

            var sql = @"
                UPDATE POSUser
                SET ConfigurationID = @configurationId
                WHERE Name = @name
            ";

            var dbResult = Execute(sql, new { name = name, configurationId = configurationId });

            result.Errors.Add(dbResult.Errors);
            if (result.IsValid) result.Value = dbResult.Value;

            return result;
        }
    }
}
