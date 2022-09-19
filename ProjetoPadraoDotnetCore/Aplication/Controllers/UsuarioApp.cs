﻿using Aplication.Interfaces;
using Aplication.Models.Request;
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
        
        if(validation.Valid)
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
}

