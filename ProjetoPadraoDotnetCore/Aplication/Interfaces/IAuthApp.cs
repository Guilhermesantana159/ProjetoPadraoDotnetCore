using Aplication.Models.Request;
using Aplication.Models.Request.Login;
using Aplication.Models.Response;

namespace Aplication.Interfaces;

public interface IAuthApp
{
    public LoginResponse Login(LoginRequest request);
}