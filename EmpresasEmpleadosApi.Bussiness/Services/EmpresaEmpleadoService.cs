using AutoMapper;
using EmpresasEmpleadosApi.Bussiness.Services.Interfaces;
using EmpresasEmpleadosApi.Data.Repository.Interface;
using EmpresasEmpleadosApi.Dto;
using EmpresasEmpleadosApi.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpresasEmpleadosApi.Bussiness.Services
{
    public class EmpresaEmpleadoService : IEmpresaEmpleadoService
    {
        private readonly IGenericRepository<EmpresaEmpleado> _genericRepository;
        private readonly IMapper _mapper;

        public EmpresaEmpleadoService(IGenericRepository<EmpresaEmpleado> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<List<EmpresaEmpleadoDTO>> ListarEmpleados()
        {            
            IQueryable<Empleado> empleados = (IQueryable<Empleado>)await _genericRepository.Consult();
            List<Empleado> listarEmpleados = new List<Empleado>();
            try
            {
                listarEmpleados = await empleados
                       .Include(de => de.DetalleEmpleados!)
                       .ThenInclude(p => p.IdEmpleadoNavigation)
                       .ToListAsync();
            }
            catch
            {
                throw;
            }
            return _mapper.Map<List<EmpresaEmpleadoDTO>>(listarEmpleados);
        }        

        public async Task<List<EmpresaEmpleadoDTO>> ListarEmpresas()
        {
            IQueryable<Empresa> empresas = (IQueryable<Empresa>)await _genericRepository.Consult();
            List<Empresa> listarEmpresas= new List<Empresa>();
            try
            {
                listarEmpresas = await empresas
                       .Include(de => de.DetalleEmpresa!)
                       .ThenInclude(p => p.IdEmpresaNavigation)
                       .ToListAsync();
            }
            catch
            {
                throw;
            }
            return _mapper.Map<List<EmpresaEmpleadoDTO>>(listarEmpresas);
        }
    }
}
