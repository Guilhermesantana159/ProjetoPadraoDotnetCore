using Aplication.Interfaces;
using Aplication.Models.Request;
using Aplication.Models.Response;
using Domain.Interfaces;

namespace Aplication.Controllers;
public class AuthApp : IAuthApp
{
    protected readonly IUsuarioService UsuarioService;

    public AuthApp(IUsuarioService usuarioService)
    {
        UsuarioService = usuarioService;
    }
    
    public LoginResponse Login(LoginRequest request)
    {
        var retorno = new LoginResponse()
        {
            Nome = "Seila",
            Autenticado = false
        };
        
        var lUsuario = UsuarioService.GetAll()
            .FirstOrDefault(x => x.Nome == request.EmailLogin && x.Senha == request.SenhaLogin);

        if (lUsuario == null)
            retorno.Autenticado = false;
        else
            retorno.Autenticado = true;

        return retorno;
    }
}

