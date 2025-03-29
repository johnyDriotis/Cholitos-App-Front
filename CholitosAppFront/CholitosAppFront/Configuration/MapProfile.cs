using AutoMapper;
using CholitosAppFront.Core.Domain;
using CholitosAppFront.Core.DTOs;

namespace CholitosAppFront.Configuration
{
    public class MapProfile : Profile
    {
        public MapProfile() {

            CreateMap<ClientDomain, ClientDto>()
                .ForMember(dest => dest.CodigoCliente, opt => opt.MapFrom(src => src.Codigo_Cliente))
                .ForMember(dest => dest.CodigoGimnasio, opt => opt.MapFrom(src => src.Codigo_Gimnasio))
                .ForMember(dest => dest.PrimerNombre, opt => opt.MapFrom(src => src.Primer_Nombre))
                .ForMember(dest => dest.SegundoNombre, opt => opt.MapFrom(src => src.Segundo_Nombre))
                .ForMember(dest => dest.PrimerApellido, opt => opt.MapFrom(src => src.Primer_Apellido))
                .ForMember(dest => dest.SegundoApellido, opt => opt.MapFrom(src => src.Segundo_Apellido))
                .ForMember(dest => dest.ApellidoCasada, opt => opt.MapFrom(src => src.Apellido_Casada))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado));
        }
    }
}
