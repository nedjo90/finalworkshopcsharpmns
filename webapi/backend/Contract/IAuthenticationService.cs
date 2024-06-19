using backend.DTOs;
using Microsoft.AspNetCore.Identity;

namespace backend.Contract;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
    Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
    Task<string> CreateToken();
    Task LogOut();


}