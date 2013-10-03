using MDPOSDemo.CC;
using MDPOSDemo.Model;

namespace MDPOSDemo.BIZ.Contracts
{
    public interface ILoginBiz
    {
        Result<LoginResult> Login(LoginRequest loginRequest);
    }
}