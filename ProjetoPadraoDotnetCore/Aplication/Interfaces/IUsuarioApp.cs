using Aplication.Models.Grid;
using Aplication.Models.Request.Usuario;
using Infraestrutura.Entity;
using ValidationResult = Aplication.Utils.Obj.ValidationResult;

namespace Aplication.Interfaces;

public interface IUsuarioApp
{
    public List<Usuario> GetAll();
    public Usuario? GetByCpf(string cpf);
    public Usuario GetById(int id);
    public ValidationResult Cadastrar(UsuarioRequest request);
    public ValidationResult CadastroInicial(UsuarioRegistroInicialRequest request);
    public void CadastrarListaUsuario(List<Usuario> lUsuario);
    public void Editar(Usuario usuario);
    public void EditarListaUsuario(List<Usuario> lUsuario);
    public void DeleteById(int id);
    public BaseGridResponse ConsultarGridUsuario(BaseGridRequest request);

}