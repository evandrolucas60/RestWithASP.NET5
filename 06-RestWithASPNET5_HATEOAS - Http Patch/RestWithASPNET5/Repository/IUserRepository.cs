using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;

namespace RestWithASPNET5.Repository
{
    public interface IUserRepository
    {
        User? ValidateCredentials(UserVO user);
        User? ValidateCredentials(String username);
        bool RevokeToken(String username);
        User? RefreshUserInfo(User user);
    }
}
