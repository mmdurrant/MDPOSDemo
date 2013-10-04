using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.BIZ.Contracts;
using MDPOSDemo.CC;
using MDPOSDemo.CC.Extenders;
using MDPOSDemo.DAL.Contracts;

namespace MDPOSDemo.BIZ
{
    public class MerchantBiz : IMerchantBiz
    {
        private IMerchantData _merchantDataInterface;

        public IMerchantData MerchantDataInterface
        {
            get { return _merchantDataInterface ?? (_merchantDataInterface = Factories.DALFactory.GetMerchantDataInterface()); }
            set { _merchantDataInterface = value; }
        }

        public Result<bool> UpdateConfigurationId(string name, string configurationId)
        {
            var result = new Result<bool>();
            var dataResult = MerchantDataInterface.UpdateConfigurationId(name, configurationId);
            if (dataResult.IsValid)
            {
                result.Value = dataResult.Value != 0;
            }
            else
            {
                result.AddError("Could not update configuration for {0}", name);
            }
            
            return result;
        }
    }
}
