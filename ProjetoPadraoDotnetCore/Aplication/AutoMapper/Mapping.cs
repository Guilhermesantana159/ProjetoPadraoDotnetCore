using Aplication.Models.Request;
using AutoMapper;
using Infraestrutura.Entity;

namespace Aplication.AutoMapper;

public class Mapping : Profile
{
    public Mapping()
    {
        #region Usuario
        CreateMap<UsuarioRequest, Usuario>();
        CreateMap<UsuarioRegistroInicialRequest, Usuario>();
        #endregion
    }
}