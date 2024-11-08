using EmpresasEmpleadosApi.Dto;

namespace EmpresasEmpleadosApi.Bussiness.Services.Interfaces
{
    public interface IMenuService
    {
        Task<List<MenuDTO>> List(int idUsuario);
    }
}
