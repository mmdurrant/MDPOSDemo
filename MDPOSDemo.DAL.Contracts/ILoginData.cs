using MDPOSDemo.CC;
using MDPOSDemo.Model;

namespace MDPOSDemo.DAL.Contracts
{
    public interface ILoginData
    {
        Result<LoginResult> Login(LoginRequest request);
    }
}
