using Aplication.Models.Request;
using Aplication.Utils.Obj;

namespace Aplication.Validators.Usuario;

public interface IUsuarioValidator
{
    public ValidationResult ValidaçãoCadastroInicial(UsuarioRegistroInicialRequest request);
}