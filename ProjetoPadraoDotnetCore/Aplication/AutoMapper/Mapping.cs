using Aplication.Models.Request;
using AutoMapper;
using Infraestrutura.Entity;

namespace Aplication.AutoMapper;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<UsuarioRequest, Usuario>();
    }
}