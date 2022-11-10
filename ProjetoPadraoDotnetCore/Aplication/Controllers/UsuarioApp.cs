using Aplication.Interfaces;
using Aplication.Models.Request.Usuario;
using Aplication.Utils.Obj;
using Aplication.Validators.Usuario;
using AutoMapper;
using Domain.Interfaces;
using Infraestrutura.Entity;
using System.Linq.Dynamic.Core;
using Aplication.Models.Grid;
using Aplication.Models.Response;
using Aplication.Utils.FilterDynamic;

namespace Aplication.Controllers;
public class UsuarioApp : IUsuarioApp
{
    protected readonly IUsuarioService Service;
    protected readonly IMapper Mapper;
    protected readonly IUsuarioValidator Validation;
    protected readonly IUtilsService UtilsService;

    public UsuarioApp(IUsuarioService service,IMapper mapper,IUsuarioValidator validation, IUtilsService utilsService)
    {
        Service = service;
        Mapper = mapper;
        Validation = validation;
        UtilsService = utilsService;
    }

    public List<Usuario> GetAll()
    {
        return Service.GetAllList();
    }

    public Usuario? GetByCpf(string cpf)
    {
        return Service.GetByCpf(cpf);
    }

    public Usuario GetById(int id)
    {
        return Service.GetById(id);
    }

    public ValidationResult Cadastrar(UsuarioRequest request)
    {
        var validation = Validation.ValidaçãoCadastro(request);
        var lUsuario = Service.GetAllList();

        if (lUsuario.Any(x => x.Email == request.Email && x.IdUsuario != request.IdUsuario))
            validation.LErrors.Add("Email já vinculado a outro usuário");

        if(validation.IsValid())
        {
            var usuario = Mapper.Map<UsuarioRequest,Usuario>(request);
            Service.Cadastrar(usuario);
        }

        return validation;
    }

    public ValidationResult CadastroInicial(UsuarioRegistroInicialRequest request)
    {
        var validation = Validation.ValidaçãoCadastroInicial(request);
        var lUsuario = Service.GetAllList();

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
        var itens = Service.GetAllQuery();
        
        itens = string.IsNullOrEmpty(request.OrderFilters?.Campo)
            ? itens.OrderByDescending(x => x.IdUsuario)
            : itens.OrderBy($"{request.OrderFilters.Campo} {request.OrderFilters.Operador.ToString()}");

        itens = itens.AplicarFiltrosDinamicos(request.QueryFilters);
        
        return new BaseGridResponse()
        {
            Itens = itens.Skip(request.Page * request.Take).Take(request.Take)
                .Select(x => new UsuarioGridResponse()
                {
                    IdUsuario = x.IdUsuario,
                    Nome = x.Nome,
                    Cpf = x.Cpf,
                    DataNascimento = x.DataNascimento.ToString(),
                    Email = x.Email,
                    Senha = x.Senha,
                    Telefone = x.Telefone,
                    Teste = x.IdUsuario == 29,
                    Perfil = x.PerfilAdministrador ? "Administrador" : "Comum",
                    ImagemUsuario = "https://i.pinimg.com/236x/33/fe/73/33fe73c8629b599c835c9d76e360f8bc--daffy-duck-duck-duck.jpg",
                    Aprovacao = 30
                }).ToList(),
            
            TotalItens = itens.Count()
        };
    }
}

