using Aplication.DTO.Grid;
using Aplication.Interfaces;
using Aplication.Models.Request.Usuario;
using Aplication.Utils.Obj;
using Aplication.Validators.Usuario;
using AutoMapper;
using Domain.Interfaces;
using Infraestrutura.Entity;

namespace Aplication.Controllers;
public class UsuarioApp : IUsuarioApp
{
    protected readonly IUsuarioService Service;
    protected readonly IMapper Mapper;
    protected readonly IUsuarioValidator Validation;

    public UsuarioApp(IUsuarioService service,IMapper mapper,IUsuarioValidator validation)
    {
        Service = service;
        Mapper = mapper;
        Validation = validation;
    }

    public List<Usuario> GetAll()
    {
        return Service.GetAll();
    }

    public Usuario? GetByCpf(string cpf)
    {
        return Service.GetByCpf(cpf);
    }

    public Usuario GetById(int id)
    {
        return Service.GetById(id);
    }

    public void Cadastrar(UsuarioRequest request)
    {
        var usuario = Mapper.Map<UsuarioRequest,Usuario>(request);
        Service.Cadastrar(usuario);
    }

    public ValidationResult CadastroInicial(UsuarioRegistroInicialRequest request)
    {
        var validation = Validation.ValidaçãoCadastroInicial(request);
        var lUsuario = Service.GetAll();

        if (lUsuario.Any(x => x.Email == request.Email))
            validation.LErrors.Add("Email já vinculado a outro usuário");
        
        if(validation.IsValid())
        {
            var usuario = Mapper.Map<UsuarioRegistroInicialRequest,Usuario>(request);
            Service.Cadastrar(usuario);
        }

        return validation;
    }

    public void CadastrarListaUsuario(List<Usuario> lUsuario)
    {
        Service.CadastrarListaUsuario(lUsuario);
    }
    
    public void Editar(Usuario usuario)
    {
        Service.Editar(usuario);
    }
    
    public void EditarListaUsuario(List<Usuario> lUsuario)
    {
        Service.EditarListaUsuario(lUsuario);
    }
    
    public void DeleteById(int id)
    {
        Service.DeleteById(id);
    }
    
    public BaseGridResponse ConsultarGridUsuario(BaseGridRequest request)
    {
        var itens = Service
            .GetAll();

        // itens = request.Order.Active == string.Empty
        //     ? itens.OrderByDescending(x => x.IdUsuario)
        //     : request.Order.Direction == "desc"
        //         ? itens.OrderByDescending(x => )
        //         : itens.OrderBy(x => request.Order.Active);
        
        return new BaseGridResponse()
        {
            Itens = itens.Skip(request.Page).Take(request.Take),
            TotalItens = itens.Count()
        };
    }
}

