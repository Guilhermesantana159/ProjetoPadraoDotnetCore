using Aplication.Interfaces;
using Aplication.Models.Request.ModuloMenu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class EstruturaMenuController : DefaultController
{
    protected readonly IEstruturaMenuApp App;
    
    public EstruturaMenuController(IEstruturaMenuApp estruturaMenuApp)
    {
        App = estruturaMenuApp;
    }

    [HttpPost]
    [Route("IntegrarModulo")]
    public JsonResult IntegrarModulo(ModuloRequest request)
    {
        try
        {
            var integracao = App.IntegrarModulo(request);
            
            if (!integracao.IsValid())
                return ResponderErro(integracao.LErrors.FirstOrDefault());
                
            return ResponderSucesso("Modulo cadastrado com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpPost]
    [Route("IntegrarMenu")]
    public JsonResult IntegrarMenu(MenuRequest request)
    {
        try
        {
            var integracao = App.IntegrarMenu(request);
            
            if (!integracao.IsValid())
                return ResponderErro(integracao.LErrors.FirstOrDefault());
                
            return ResponderSucesso("Menu cadastrado com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [Authorize]
    [HttpGet]
    [Route("ConsultarEstruturaMenus")]
    public JsonResult ConsultarEstruturaMenus()
    {
        try
        {
            var integracao = App.ConsultarEstruturaMenus();

            return ResponderSucesso(integracao);
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
}