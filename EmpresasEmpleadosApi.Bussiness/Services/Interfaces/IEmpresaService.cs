using EmpresasEmpleadosApi.Dto;

namespace EmpresasEmpleadosApi.Bussiness.Services.Interfaces
{
    public interface IEmpresaService
    {
        Task<List<EmpresaDTO>> ListarEmpresas();
        Task<EmpresaDTO> Crear(EmpresaDTO model);
        Task<bool> Editar(EmpresaDTO model);
        Task<bool> Borrar(int idEmpresa);
    }
}
