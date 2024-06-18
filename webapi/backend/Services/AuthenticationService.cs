using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using backend.Contract;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace backend.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly JwtConfiguration _jwtConfiguration;
    private readonly IConfiguration _configuration;
    private User? _user;

    public AuthenticationService
    (IMapper mapper, UserManager<User> userManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _mapper = mapper;
        _jwtConfiguration = new JwtConfiguration();
        configuration.Bind(_jwtConfiguration.Section, _jwtConfiguration);
        _configuration = configuration;
    }

    public async Task<IdentityResult> RegisterUser(UserForRegistrationDto
        userForRegistration)
    {
        User? user = _mapper.Map<User>(userForRegistration);
        IdentityResult result = await _userManager.CreateAsync(user,
            userForRegistration.Password);
        return result;
    }

    public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
    {
        _user = await _userManager.FindByNameAsync(userForAuth.UserName);
        bool result = (_user != null && await _userManager.CheckPasswordAsync(_user,
            userForAuth.Password));
        return result;
    }
    public async Task<string> CreateToken()
    {
        SigningCredentials signingCredentials = GetSigningCredentials();
        JwtSecurityToken tokenOptions = GenerateTokenOptions(signingCredentials);
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private SigningCredentials GetSigningCredentials()
    {
        byte[] key =
            Encoding.UTF8.GetBytes(_jwtConfiguration.SecretKey);
        SymmetricSecurityKey secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials)
    {
        //var jwtSettings = _configuration.GetSection("JwtSettings");
        JwtSecurityToken tokenOptions = new JwtSecurityToken
        (
            issuer: _jwtConfiguration.ValidIssuer,
            audience: _jwtConfiguration.ValidAudience,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
            signingCredentials: signingCredentials
        );
        return tokenOptions;
    }
}