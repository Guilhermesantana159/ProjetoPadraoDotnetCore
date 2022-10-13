using Aplication.Models.Request;
using Aplication.Models.Request.Usuario;
using Aplication.Utils.Obj;
using Aplication.Utils.ValidatorDocument;

namespace Aplication.Validators.Usuario;

public class UsuarioValidator : IUsuarioValidator
{
    private readonly IValidatorDocument _util;
    public UsuarioValidator(IValidatorDocument utilDocument)
    {
        _util = utilDocument;
    }

    public ValidationResult ValidaçãoCadastroInicial(UsuarioRegistroInicialRequest request)
    {
        var validation = new ValidationResult();
        
        if(string.IsNullOrEmpty(request.Email))
            validation.LErrors.Add("Campo Email é obrigatório!");
        if(string.IsNullOrEmpty(request.Nome))
            validation.LErrors.Add("Campo nome é obrigatório!");
        if(string.IsNullOrEmpty(request.Senha))
            validation.LErrors.Add("Campo senha é obrigatório!");
        if(string.IsNullOrEmpty(request.CPF))
            validation.LErrors.Add("Campo CPF é obrigatório!");
        if(!_util.ValidatorCpf(request.CPF))
            validation.LErrors.Add("Campo CPF inválido!");
        
        return validation;    
    }
}