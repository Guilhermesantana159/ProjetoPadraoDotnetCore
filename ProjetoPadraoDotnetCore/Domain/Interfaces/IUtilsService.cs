using Domain.DTO.Correios;
using Infraestrutura.Entity;

namespace Domain.Interfaces;

public interface IUtilsService
{
    public Task<EnderecoExternalReponse> ConsultarEnderecoCep(string cep);
    public IQueryable<Profissao> ConsultarProfissoes();
    public void CadastrarProfissao(Profissao profissao);
    public void EditarProfissao(Profissao profissao);
    public Profissao GetProfissaoById(int id);
    public void DeletarProfissaoPorId(int id);
    public IQueryable<SkillUsuario> ConsultarSkill();
    public void CadastrarSkill(SkillUsuario profissao);
    public void EditarSkill(SkillUsuario profissao);
    public SkillUsuario GetSkillById(int id);
    public void DeletarSkillPorId(int id);

}