using Aplication.Models.Request;
using Aplication.Models.Request.Usuario;
using ValidationResult = Aplication.Utils.Obj.ValidationResult;

namespace Aplication.Validators.Usuario;

public interface IUsuarioValidator
{
    public ValidationResult ValidaçãoCadastroInicial(UsuarioRegistroInicialRequest request);
    public ValidationResult ValidaçãoCadastro(UsuarioRequest request);
}