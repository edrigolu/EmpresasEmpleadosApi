using AutoMapper;
using EmpresasEmpleadosApi.Dto;
using EmpresasEmpleadosApi.Entities.Models;

namespace EmpresasEmpleadosApi.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Empresa
            CreateMap<Empresa, EmpresaDTO>().ReverseMap();
            #endregion

            #region Empleado
            CreateMap<Empleado, EmpleadoDTO>().ReverseMap();
            #endregion

            #region Empresa-Empleado
            CreateMap<EmpresaEmpleado, EmpresaEmpleadoDTO>()
                .ForMember(destination => destination.NombreEmpresa, option => option.MapFrom(source => source.IdEmpresaNavigation!.NombreEmpresa)
                )
                .ForMember(destination => destination.Nombres, option => option.MapFrom(source => source.IdEmpleadoNavigation!.Nombres)
                )
                .ForMember(destination => destination.Apellidos, option => option.MapFrom(source => source.IdEmpleadoNavigation!.Apellidos)
                )
                 .ForMember(destination => destination.EstadoRegistro,
                option => option.MapFrom(source => source.EstadoRegistro == true ? 1 : 0)
                );

            CreateMap<EmpresaEmpleadoDTO, EmpresaEmpleado>()
                .ForMember(destination => destination.IdEmpresaNavigation,
                option => option.Ignore()
                )
                 .ForMember(destination => destination.IdEmpleadoNavigation,
                            option => option.Ignore())
                .ForMember(destination => destination.EstadoRegistro,
                option => option.MapFrom(source => source.EstadoRegistro == 1 ? true : false)
                );
            #endregion

            #region Rol
            CreateMap<Rol, RolDTO>().ReverseMap();
            #endregion Rol

            #region Usuario
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(destination =>
                destination.RolDescripcion,
                option => option.MapFrom(source => source.IdRolNavigation!.RolDescripcion)
                )
                .ForMember(destination => destination.Activo,
                option => option.MapFrom(source => source.Activo == true ? 1 : 0)
                );

            CreateMap<Usuario, SessionDTO>()
                .ForMember(destination =>
              destination.RolDescripcion, option =>
                  option.MapFrom(source => source.IdRolNavigation!.RolDescripcion)
              );

            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(destination => destination.IdRolNavigation,
                option => option.Ignore())
                .ForMember(destination => destination.Activo,
                option => option.MapFrom(source => source.Activo == 1 ? true : false)
                );
            #endregion

        }
    }
}
