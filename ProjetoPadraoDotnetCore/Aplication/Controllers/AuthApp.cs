using Aplication.Authentication;
using Aplication.Interfaces;
using Aplication.Models.Request.Login;
using Aplication.Models.Response;
using Aplication.Utils.HashCripytograph;
using Domain.Interfaces;

namespace Aplication.Controllers;

public class AuthApp : IAuthApp
{
    protected readonly IUsuarioService UsuarioService;
    protected readonly IHashCriptograph Crypto;
    protected readonly IJwtTokenAuthentication Jwt;

    public AuthApp(IUsuarioService usuarioService,IHashCriptograph crypto,IJwtTokenAuthentication jwt)
    {
        UsuarioService = usuarioService;
        Crypto = crypto;
        Jwt = jwt;
    }

    public LoginResponse Login(LoginRequest request)
    {
        var retorno = new LoginResponse();

        var usuario = UsuarioService.GetAllList()
            .FirstOrDefault(x => x.Email == request.EmailLogin && x.Senha ==
                Crypto.Hash(request.SenhaLogin));

        if (usuario == null)
            retorno.Autenticado = false;
        else
        {
            retorno.Autenticado = true;
            retorno.Nome = usuario.Nome;
            retorno.SessionKey = Jwt.GerarToken(usuario.Cpf);
        }

        return retorno;
    }
}