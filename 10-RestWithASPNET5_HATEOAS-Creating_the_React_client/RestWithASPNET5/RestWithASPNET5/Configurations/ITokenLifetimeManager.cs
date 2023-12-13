using Microsoft.IdentityModel.Tokens;

namespace RestWithASPNET5.Configurations
{
    public interface ITokenLifetimeManager
    {
        bool ValidateToken(DateTime? notBefore,
                      DateTime? expires,
                      SecurityToken securityToken,
                      TokenValidationParameters validationParameters);

        void SignOut(SecurityToken securityToken);
    }
}
