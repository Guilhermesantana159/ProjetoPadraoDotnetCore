using Aplication.Interfaces;
using Aplication.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : DefaultController
{
    protected readonly IAuthApp App;
    
    public AuthController(IAuthApp authApp)
    {
        App = authApp;
    }

    [HttpPost]
    [Route("Login")]
    public JsonResult Login(LoginRequest request)
    {
        try
        {
            var retorno = App.Login(request);

            if (!retorno.Autenticado)
                return ResponderErro("Usuário ou senha inválido!");
            
            return ResponderSucesso(retorno);
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
}