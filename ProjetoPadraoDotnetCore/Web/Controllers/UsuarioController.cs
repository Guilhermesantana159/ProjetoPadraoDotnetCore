using Aplication.Interfaces;
using Aplication.Models.Request;
using Aplication.Models.Response;
using Infraestrutura.Entity;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : DefaultController
{
    protected readonly IUsuarioApp App;
    
    public UsuarioController(IUsuarioApp usuarioApp)
    {
        App = usuarioApp;
    }

    [HttpPost]
    [Route("Cadastrar")]
    public JsonResult Cadastrar(UsuarioRequest request)
    {
        try
        {
            App.Cadastrar(request);
            return ResponderSucesso("Usuário cadastrado com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }

    [HttpGet]
    [Route("ConsultarTodos")]
    public JsonResult ConsultarTodos()
    {
        try
        {
            var objeto = new UsuarioResponse()
            {
                itens = App.GetAll()
            };
            
            return ResponderSucesso(objeto);
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }

    [HttpGet]
    [Route("ConsultarViaId")]
    public JsonResult ConsultarViaId(int id)
    {
        try
        {
            return ResponderSucesso(App.GetById(id));
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }

    [HttpPost]
    [Route("CadastrarListaUsuario")]
    public JsonResult CadastrarListaUsuario(List<Usuario> lUsuario)
    {
        try
        {
            App.CadastrarListaUsuario(lUsuario);
            return ResponderSucesso("usuários cadastrado com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpPost]
    [Route("Editar")]
    public JsonResult Editar(Usuario usuario)
    {
        try
        {
            App.Editar(usuario);
            return ResponderSucesso("Usuário editado com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpPost]
    [Route("EditarListaUsuario")]
    public JsonResult EditarListaUsuario(List<Usuario> lUsuario)
    {
        try
        {
            App.EditarListaUsuario(lUsuario);
            return ResponderSucesso("Usuário ");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpPost]
    [Route("DeleteById")]
    public JsonResult DeleteById(int id)
    {
        try
        {
            App.DeleteById(id);
            return ResponderSucesso("Usuário deletado com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
}