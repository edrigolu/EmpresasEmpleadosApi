using EmpresasEmpleadosApi.Dto;

namespace EmpresasEmpleadosApi.Bussiness.Services.Interfaces
{
    public interface IEmpleadoService
    {
        Task<List<EmpleadoDTO>> List();
        Task<EmpleadoDTO> Create(EmpleadoDTO model);
        Task<bool> Edit(EmpleadoDTO model);
        Task<bool> Delete(int idEmpleado);
    }
}
