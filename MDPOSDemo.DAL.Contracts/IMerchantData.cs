using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.CC;

namespace MDPOSDemo.DAL.Contracts
{
    public interface IMerchantData
    {
        Result<int> UpdateConfigurationId(string name, string configurationId);
    }
}
