using EmpresasEmpleadosApi.Dto;

namespace EmpresasEmpleadosApi.Bussiness.Services.Interfaces
{
    public interface IEmpresaService
    {
        Task<List<EmpresaDTO>> List();
        Task<EmpresaDTO> Create(EmpresaDTO model);
        Task<bool> Edit(EmpresaDTO model);
        Task<bool> Delete(int idEmpresa);
        Task<EmpresaEmpleadoDTO> Register(EmpresaEmpleadoDTO model);
    }
}
