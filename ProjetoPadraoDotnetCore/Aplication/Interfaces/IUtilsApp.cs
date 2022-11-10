using Aplication.Models.Request.Profissao;
using Aplication.Models.Request.SkillUsuario;
using Aplication.Models.Response;

namespace Aplication.Interfaces;

public interface IUtilsApp
{
    public EnderecoResponse ConsultarEnderecoCep(string cep);
    public void CadastrarProfissao(ProfissaoCadastrarRequest request);
    public List<SelectBaseResponse> ConsultarProfissoes();
    public void EditarProfissao(ProfissaoEditarRequest profissao);
    public void DeletarProfissaoPorId(int id);
    public List<SelectBaseResponse> ConsultarSkills();
    public void EditarSkill(SkillUsuarioEditarRequest profissao);
    public void DeletarSkillPorId(int id);
    public void CadastrarSkill(SkillUsuarioCadastrarRequest request);
}