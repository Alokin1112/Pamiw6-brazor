using Microsoft.Extensions.Options;
using Pamiw6.Shared.Configuration;
using Pamiw6.Shared.Interfaces;
using Pamiw6.Shared.Models;
using System.Net.Http.Json;

namespace Pamiw6.shared.services
{
  public class AuthService : IAuthService
  {

    private readonly HttpClient _httpClient;
    private readonly AppSettings _appSettings;

    public AuthService(HttpClient httpClient, IOptions<AppSettings> appSettings)
    {
      _httpClient = httpClient;
      _appSettings = appSettings.Value;

    }

    public async Task<ServiceResponse<AuthenticationResponse>> Login(AuthenticationRequest userLoginDto)
    {
      var result = await _httpClient.PostAsJsonAsync(_appSettings.BaseAPIUrl + _appSettings.AuthEndpoint.Login, userLoginDto);
      var data = await result.Content.ReadFromJsonAsync<ServiceResponse<AuthenticationResponse>>();

      return data;
    }

    public async Task<ServiceResponse<AuthenticationResponse>> Register(AuthenticationRequest userRegisterDTO)
    { 
      var result = await _httpClient.PostAsJsonAsync(_appSettings.BaseAPIUrl + _appSettings.AuthEndpoint.Register, userRegisterDTO);
      return await result.Content.ReadFromJsonAsync<ServiceResponse<AuthenticationResponse>>();
    }

  }
}
