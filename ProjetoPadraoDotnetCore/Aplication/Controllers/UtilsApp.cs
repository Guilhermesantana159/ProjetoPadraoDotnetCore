using Aplication.Interfaces;
using Aplication.Models.Request.Profissao;
using Aplication.Models.Request.SkillUsuario;
using Aplication.Models.Response;
using Aplication.Validators.Utils;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DTO.Correios;
using Domain.Interfaces;
using Infraestrutura.Entity;

namespace Aplication.Controllers;

public class UtilsApp : IUtilsApp
{
    protected readonly IUtilsService UtilsService;
    protected readonly IUtilsValidator UtilsValidation;
    protected readonly IMapper Mapper;

    public UtilsApp(IUtilsService utilsService,IUtilsValidator utilsValidation,IMapper mapper)
    {
        UtilsService = utilsService;
        UtilsValidation = utilsValidation;
        Mapper = mapper;
    }

    public EnderecoResponse ConsultarEnderecoCep(string cep)
    {
        var validation = UtilsValidation.ValidarCep(cep);

        if (!validation.IsValid())
            return Mapper.Map<EnderecoResponse>(validation);

        var retorno = UtilsService.ConsultarEnderecoCep(cep).Result;
        
        return Mapper.Map<EnderecoExternalReponse,EnderecoResponse>(retorno);
    }

    public List<SelectBaseResponse> ConsultarProfissoes()
    {
        return UtilsService.ConsultarProfissoes()
            .ProjectTo<SelectBaseResponse>(Mapper.ConfigurationProvider).ToList();
    }

    public void CadastrarProfissao(ProfissaoCadastrarRequest profissao)
    { 
        UtilsService.CadastrarProfissao(Mapper.Map<Profissao>(profissao));
    }
    
    public void EditarProfissao(ProfissaoEditarRequest profissaoRequest)
    {
        var profissao = UtilsService.GetProfissaoById(profissaoRequest.IdProfissao);

        if (profissao == null)
            throw new Exception("Id não pertence a nenhuma profissão!");

        UtilsService.EditarProfissao(Mapper.Map<ProfissaoEditarRequest,Profissao>(profissaoRequest));
    }

    public void DeletarProfissaoPorId(int id)
    {
        UtilsService.DeletarProfissaoPorId(id);
    }

    public List<SelectBaseResponse> ConsultarSkills()
    {
        return UtilsService.ConsultarSkill()
            .ProjectTo<SelectBaseResponse>(Mapper.ConfigurationProvider).ToList();
    }

    public void CadastrarSkill(SkillUsuarioCadastrarRequest profissao)
    { 
        UtilsService.CadastrarSkill(Mapper.Map<SkillUsuario>(profissao));
    }
    
    public void EditarSkill(SkillUsuarioEditarRequest profissaoRequest)
    {
        var profissao = UtilsService.GetSkillById(profissaoRequest.IdSkillUsuario);

        if (profissao == null)
            throw new Exception("Id não pertence a nenhuma skill!");

        UtilsService.EditarSkill(Mapper.Map<SkillUsuarioEditarRequest,SkillUsuario>(profissaoRequest));
    }

    public void DeletarSkillPorId(int id)
    {
        UtilsService.DeletarSkillPorId(id);
    }
}