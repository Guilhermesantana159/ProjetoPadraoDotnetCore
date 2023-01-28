using Aplication.Authentication;
using Aplication.Interfaces;
using Aplication.Models.Request.Login;
using Aplication.Models.Response.Auth;
using Aplication.Utils.HashCripytograph;
using Domain.Interfaces;
using Infraestrutura.Enum;

namespace Aplication.Controllers;

public class AuthApp : IAuthApp
{
    protected readonly IUsuarioService UsuarioService;
    protected readonly IHashCriptograph Crypto;
    protected readonly IJwtTokenAuthentication Jwt;
    private readonly IConfiguration _configuration;
    public AuthApp(IUsuarioService usuarioService,IHashCriptograph crypto,IJwtTokenAuthentication jwt, IConfiguration configuration)
    {
        UsuarioService = usuarioService;
        Crypto = crypto;
        Jwt = jwt;
        _configuration = configuration;
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
            retorno.IdUsuario = usuario.IdUsuario;
            retorno.Foto = usuario.Foto == null
                ? usuario.Genero == EGenero.Masculino
                    ? _configuration.GetSection("ImageDefaultUser:Masculino").Value
                    : _configuration.GetSection("ImageDefaultUser:Feminino").Value
                : usuario.Foto;
        }

        return retorno;
    }
}