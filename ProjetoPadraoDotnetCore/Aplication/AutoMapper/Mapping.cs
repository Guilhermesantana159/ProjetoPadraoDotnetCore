using Aplication.Models.Request.ModuloMenu;
using Aplication.Models.Request.Usuario;
using Aplication.Models.Response;
using Aplication.Utils.HashCripytograph;
using AutoMapper;
using Infraestrutura.Entity;

namespace Aplication.AutoMapper;

public class Mapping : Profile
{
    public Mapping()
    {
        #region Usuario
        CreateMap<UsuarioRequest, Usuario>();
        CreateMap<UsuarioRegistroInicialRequest, Usuario>()
            .ForMember(dst => dst.Senha,
                map => map.MapFrom(src => new HashCripytograph().Hash(src.Senha)));
        #endregion
        
        #region ModuloMenu

        CreateMap<ModuloRequest, Modulo>()
            .ForMember(dst => dst.IdModulo,
                map => map.MapFrom(src => src.Id));

        CreateMap<MenuRequest, Menu>();
        
        CreateMap<Modulo, ModuloResponse>()
            .ForMember(dst => dst.lMenus,
                map => map.MapFrom(src => src.lMenus));

        CreateMap<Menu, LMenu>();

        #endregion
    }
}