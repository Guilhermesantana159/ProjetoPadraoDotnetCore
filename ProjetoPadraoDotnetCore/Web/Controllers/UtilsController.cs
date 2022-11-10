using Aplication.Interfaces;
using Aplication.Models.Request.Profissao;
using Aplication.Models.Request.SkillUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UtilsController : DefaultController
{
    protected readonly IUtilsApp UtilsApp;

    public UtilsController(IUtilsApp utilApp)
    {
        UtilsApp = utilApp;
    }

    [HttpGet]
    [Authorize]
    [Route("ConsultarEnderecoCep/{cep}")]
    public JsonResult ConsultarEnderecoCep(string cep)
    {
        try
        {
            var retorno = UtilsApp.ConsultarEnderecoCep(cep);

            if (!retorno.IsValid())
                return ResponderErro("Cep inválido!");

            return ResponderSucesso(retorno);
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpGet]
    [Authorize]
    [Route("ConsultarProfissoes")]
    public JsonResult ConsultarProfissoes()
    {
        try
        {
            var retorno = UtilsApp.ConsultarProfissoes();

            return ResponderSucesso(retorno);
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpPost]
    [Authorize]
    [Route("CadastrarProfissao")]
    public JsonResult CadastrarProfissao(ProfissaoCadastrarRequest request)
    {
        try
        {
            UtilsApp.CadastrarProfissao(request);

            return ResponderSucesso("Profissão cadastrada com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpPost]
    [Authorize]
    [Route("EditarProfissao")]
    public JsonResult EditarProfissao(ProfissaoEditarRequest request)
    {
        try
        {
            UtilsApp.EditarProfissao(request);

            return ResponderSucesso("Profissão editada com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpPost]
    [Authorize]
    [Route("DeletarProfissaoPorId")]
    public JsonResult DeletarProfissaoPorId(int id)
    {
        try
        {
            UtilsApp.DeletarProfissaoPorId(id);

            return ResponderSucesso("Profissão apagada com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpGet]
    [Authorize]
    [Route("ConsultarSkills")]
    public JsonResult ConsultarSkills()
    {
        try
        {
            var retorno = UtilsApp.ConsultarSkills();

            return ResponderSucesso(retorno);
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpPost]
    [Authorize]
    [Route("CadastrarSkill")]
    public JsonResult CadastrarSkill(SkillUsuarioCadastrarRequest request)
    {
        try
        {
            UtilsApp.CadastrarSkill(request);

            return ResponderSucesso("Skill cadastrada com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpPost]
    [Authorize]
    [Route("EditarSkill")]
    public JsonResult EditarSkill(SkillUsuarioEditarRequest request)
    {
        try
        {
            UtilsApp.EditarSkill(request);

            return ResponderSucesso("Skill editada com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpPost]
    [Authorize]
    [Route("DeletarSkillPorId")]
    public JsonResult DeletarSkillPorId(int id)
    {
        try
        {
            UtilsApp.DeletarSkillPorId(id);

            return ResponderSucesso("Skill apagada com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
}