using Aplication.Interfaces;
using Aplication.Models.Request;
using AutoMapper;
using Domain.Interfaces;
using Infraestrutura.Entity;

namespace Aplication.Controllers;
public class UsuarioApp : IUsuarioApp
{
    protected readonly IUsuarioService Service;
    protected readonly IMapper Mapper;

    public UsuarioApp(IUsuarioService service,IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    public List<Usuario> GetAll()
    {
        return Service.GetAll();
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
}

