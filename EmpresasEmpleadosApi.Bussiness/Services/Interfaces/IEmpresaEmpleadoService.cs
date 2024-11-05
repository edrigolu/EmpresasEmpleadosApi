using EmpresasEmpleadosApi.Dto;

namespace EmpresasEmpleadosApi.Bussiness.Services.Interfaces
{
    public interface IEmpresaEmpleadoService
    {
        Task<List<EmpresaEmpleadoDTO>> ListarEmpresas();
        Task<List<EmpresaEmpleadoDTO>> ListarEmpleados();
    }
}
