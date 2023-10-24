using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    public UsuarioController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    [HttpPost("Criar")]
    public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model)
    {
        return await CreateUserExecute(model);
    }

    [HttpPost("CriarAdmin")]
    public async Task<ActionResult<UserToken>> CreateAdminUser([FromBody] UserInfo model)
    {
        return await CreateUserExecute(model, "Admin");
    }

    private async Task<ActionResult<UserToken>> CreateUserExecute(UserInfo model, string roleName = "Member")
    {
        var user = new IdentityUser { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            var roleResult = await _userManager.AddToRoleAsync(user, roleName);

            if (roleResult.Succeeded)
                return BuildToken(model);
            else
                return BadRequest("Erro ao atribuir o usuário a um grupo");
        }
        else
        {
            return BadRequest("Usuário ou senha inválidos");
        }
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
    {
        var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, 
                isPersistent: false, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            return BuildToken(userInfo);
        }
        else
        {
            ModelState.AddModelError(string.Empty, "login inválido.");
            return BadRequest(ModelState);
        }
    }

    private UserToken BuildToken(UserInfo userInfo)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // tempo de expiração do token: 1 hora
        var expiration = DateTime.UtcNow.AddHours(1);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: expiration,
            signingCredentials: creds);

        return new UserToken()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }

    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;
}