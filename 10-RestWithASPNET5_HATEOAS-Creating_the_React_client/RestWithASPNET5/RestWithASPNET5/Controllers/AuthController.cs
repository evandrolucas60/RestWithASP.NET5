using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET5.Business;
using RestWithASPNET5.Configurations;
using RestWithASPNET5.Data.VO;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

[ApiVersion("1")]
[Route("api/[controller]/v{version:apiVersion}")]
[ApiController]
public class AuthController : ControllerBase
{
    private ILoginBusiness _loginBusiness;
    private readonly ITokenLifetimeManager tokenLifetimeManager;


    public AuthController(ILoginBusiness loginBusiness)
    {
        _loginBusiness = loginBusiness;
    }

    [HttpPost]
    [Route("signin")]
    public IActionResult Signin([FromBody] UserVO user)
    {
        if (user == null) return BadRequest("Ivalid client request");
        var token = _loginBusiness.ValidateCredentials(user);
        if (token == null) return Unauthorized();
        return Ok(token);
    }

    [HttpPost]
    [Route("refresh")]
    public IActionResult Refresh([FromBody] TokenVO tokenVo)
    {
        if (tokenVo is null) return BadRequest("Ivalid client request");
        var token = _loginBusiness.ValidateCredentials(tokenVo);
        if (token == null) return BadRequest("Ivalid client request");
        return Ok(token);
    }


    [HttpPost("logout")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public IActionResult LogOut([FromHeader(Name = "Authorization")] string? authorization)
    {
        if (string.IsNullOrWhiteSpace(authorization)) return Ok();

        string bearerToken =
           authorization.Replace("Bearer ", string.Empty, StringComparison.InvariantCultureIgnoreCase);

        tokenLifetimeManager.SignOut(new JwtSecurityToken(bearerToken));

        return Ok();
    }
}