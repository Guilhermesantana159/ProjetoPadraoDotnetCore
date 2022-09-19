using Aplication.Models.Request;
using Aplication.Utils.Obj;

namespace Aplication.Validators.Usuario;

public class UsuarioValidator : IUsuarioValidator
{
    public ValidationResult ValidaçãoCadastroInicial(UsuarioRegistroInicialRequest request)
    {
        var retorno = new ValidationResult();

        if(request.Cpf == "")
            ValidationResult.Errors.Add("Campo CPF é obrigatório!");

        return retorno;    
    }
}