using MDPOSDemo.CC;

namespace MDPOSDemo.BIZ.Contracts
{
    public interface IMerchantBiz
    {
        Result<bool> UpdateConfigurationId(string name, string configurationId);

    }
}