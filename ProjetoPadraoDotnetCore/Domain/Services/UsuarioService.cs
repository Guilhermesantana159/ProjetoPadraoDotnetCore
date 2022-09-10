﻿using Domain.Interfaces;
using Infraestrutura.Entity;
using Infraestrutura.Repository.Interface.Usuario;

namespace Domain.Services;

public class UsuarioService : IUsuarioService
{
    protected readonly IUsuarioReadRepository ReadRepository;
    protected readonly IUsuarioWriteRepository WriteRepository;

    public UsuarioService(IUsuarioReadRepository readRepository,IUsuarioWriteRepository writeRepository)
    {
        ReadRepository = readRepository;
        WriteRepository = writeRepository;
    }

    public Usuario GetById(int id)
    {
        return ReadRepository.GetById(id);
    }
    
    public List<Usuario> GetAll()
    {
        return ReadRepository.GetAll().ToList();
    }

    public void Cadastrar(Usuario usuario)
    {
        WriteRepository.Add(usuario);
    }
    
    public void CadastrarListaUsuario(List<Usuario> lUsuario)
    {
        WriteRepository.AddRange(lUsuario);
    }
    
    public void Editar(Usuario usuario)
    {
        WriteRepository.Update(usuario);
    }
    
    public void EditarListaUsuario(List<Usuario> lUsuario)
    {
        WriteRepository.UpdateRange(lUsuario);
    }
    
    public void DeleteById(int id)
    {
        WriteRepository.DeleteById(id);
    }
}