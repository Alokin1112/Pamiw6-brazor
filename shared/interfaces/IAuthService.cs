using Pamiw6.Shared.Models;

namespace Pamiw6.Shared.Interfaces
{
  public interface IAuthService
  {
    Task<ServiceResponse<AuthenticationResponse>> Login(AuthenticationRequest userLoginDto);

    Task<ServiceResponse<AuthenticationResponse>> Register(AuthenticationRequest userRegisterDTO);
  }
}
