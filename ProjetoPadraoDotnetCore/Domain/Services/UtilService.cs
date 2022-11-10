using System.Net;
using System.Text.Json;
using Domain.DTO.Correios;
using Domain.Interfaces;
using Infraestrutura.Entity;
using Infraestrutura.Repository.External;
using Infraestrutura.Repository.Interface.Profissao;
using Infraestrutura.Repository.Interface.SkillUsuario;

namespace Domain.Services;

public class UtilService : IUtilsService
{
    protected readonly IExternalRepository External;
    protected readonly IProfissaoReadRepository ProfissaoReadRepository;
    protected readonly IProfissaoWriteRepository ProfissaoWriteRepository;
    protected readonly ISkillUsuarioReadRepository SkillReadRepository;
    protected readonly ISkillUsuarioWriteRepository SkillWriteRepository;

    private readonly IConfiguration _configuration;
    public UtilService(IExternalRepository external,IConfiguration config, IProfissaoReadRepository profissaoReadRepository, IProfissaoWriteRepository profissaoWriteRepository, ISkillUsuarioWriteRepository skillWriteRepository, ISkillUsuarioReadRepository skillReadRepository)
    {
        External = external;
        _configuration = config;
        ProfissaoReadRepository = profissaoReadRepository;
        ProfissaoWriteRepository = profissaoWriteRepository;
        SkillWriteRepository = skillWriteRepository;
        SkillReadRepository = skillReadRepository;
    }
    public async Task<EnderecoExternalReponse> ConsultarEnderecoCep(string cep)
    {
        EnderecoExternalReponse retorno;
        var url = _configuration.GetSection("ApiCorreios:Link");       
        var requisicao = await External.SendWebHttp(url.Value + cep +"/json");

        if (requisicao.StatusCode == HttpStatusCode.OK)
        {
            if (requisicao.ObjetoJson != null)
            { 
                retorno = JsonSerializer.Deserialize<EnderecoExternalReponse>(requisicao.ObjetoJson)
                        ?? new EnderecoExternalReponse() { StatusApi = false, StatusCode = requisicao.StatusCode };

                if (string.IsNullOrEmpty(retorno.bairro) || string.IsNullOrEmpty(retorno.localidade) || string.IsNullOrEmpty(retorno.uf) 
                    || string.IsNullOrEmpty(retorno.logradouro))
                {
                    retorno.StatusApi = false;
                }
                
                return retorno;
            }
            
        }
        
        retorno = JsonSerializer.Deserialize<EnderecoExternalReponse>(requisicao.ObjetoJson ?? "")
               ?? new EnderecoExternalReponse() { StatusApi = false, StatusCode = requisicao.StatusCode };
        
        if (string.IsNullOrEmpty(retorno.bairro) || string.IsNullOrEmpty(retorno.localidade) || string.IsNullOrEmpty(retorno.uf) 
            || string.IsNullOrEmpty(retorno.logradouro))
        {
            retorno.StatusApi = false;
        }

        return retorno;
    }

    public IQueryable<Profissao> ConsultarProfissoes()
    {
        return ProfissaoReadRepository.GetAll();
    }
    
    public void CadastrarProfissao(Profissao profissao)
    { 
        ProfissaoWriteRepository.Add(profissao);
    }
    
    public void EditarProfissao(Profissao profissao)
    { 
        ProfissaoWriteRepository.Update(profissao);
    }
    
    public Profissao GetProfissaoById(int id)
    { 
        return ProfissaoReadRepository.GetById(id);
    }
    
    public void DeletarProfissaoPorId(int id)
    { 
        ProfissaoWriteRepository.DeleteById(id);
    }

    public IQueryable<SkillUsuario> ConsultarSkill()
    {
        return SkillReadRepository.GetAll();
    }

    public void CadastrarSkill(SkillUsuario profissao)
    { 
        SkillWriteRepository.Add(profissao);
    }
    
    public void EditarSkill(SkillUsuario profissao)
    { 
        SkillWriteRepository.Update(profissao);
    }
    
    public SkillUsuario GetSkillById(int id)
    { 
        return SkillReadRepository.GetById(id);
    }
    
    public void DeletarSkillPorId(int id)
    { 
        SkillWriteRepository.DeleteById(id);
    }
}