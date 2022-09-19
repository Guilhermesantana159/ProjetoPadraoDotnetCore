using Aplication.Models.Request;
using Aplication.Utils.Obj;
using Infraestrutura.Entity;

namespace Aplication.Interfaces;

public interface IUsuarioApp
{
    public List<Usuario> GetAll();
    public Usuario GetById(int id);
    public void Cadastrar(UsuarioRequest request);
    public ValidationResult CadastroInicial(UsuarioRegistroInicialRequest request);
    public void CadastrarListaUsuario(List<Usuario> lUsuario);
    public void Editar(Usuario usuario);
    public void EditarListaUsuario(List<Usuario> lUsuario);
    public void DeleteById(int id);
}