using RestWithASPNET5.Data.VO;

namespace RestWithASPNET5.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
    }
}
