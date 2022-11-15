using Aplication.Models.Request;
using Aplication.Models.Request.Login;
using Aplication.Models.Response;
using Aplication.Models.Response.Auth;

namespace Aplication.Interfaces;

public interface IAuthApp
{
    public LoginResponse Login(LoginRequest request);
}