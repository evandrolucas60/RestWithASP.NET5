using System.Security.Claims;

namespace RestWithASPNET5.Services
{
    public interface ITokenInterface
    {
        string GenerateAcessToken(IEnumerable<Claim> clains);
        string GenerateRefreshToken();
        ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string token);
    }
}
