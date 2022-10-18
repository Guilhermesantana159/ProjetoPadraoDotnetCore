﻿using Aplication.DTO.Grid;
using Aplication.Interfaces;
using Aplication.Models.Request.Usuario;
using Aplication.Utils.Obj;
using Aplication.Validators.Usuario;
using AutoMapper;
using Domain.Interfaces;
using Infraestrutura.Entity;
using System.Linq.Dynamic.Core;
using Aplication.Utils.FilterDynamic;

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

    public void Cadastrar(UsuarioRequest request)
    {
        var usuario = Mapper.Map<UsuarioRequest,Usuario>(request);
        Service.Cadastrar(usuario);
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
            Itens = itens.Skip(request.Page).Take(request.Take).ToList(),
            TotalItens = itens.Count()
        };
    }
}

