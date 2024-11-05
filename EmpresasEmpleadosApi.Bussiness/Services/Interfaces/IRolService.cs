using EmpresasEmpleadosApi.Dto;

namespace EmpresasEmpleadosApi.Bussiness.Services.Interfaces
{
    public interface IRolService
    {
        Task<List<RolDTO>> Listar();
    }
}
