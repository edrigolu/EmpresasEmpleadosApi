using AutoMapper;
using EmpresasEmpleadosApi.Bussiness.Services.Interfaces;
using EmpresasEmpleadosApi.Data.Repository.Interface;
using EmpresasEmpleadosApi.Dto;
using EmpresasEmpleadosApi.Entities.Models;

namespace EmpresasEmpleadosApi.Bussiness.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IGenericRepository<Empleado> _empleadoRepository;
        private readonly IMapper _mapper;

        public EmpleadoService(IGenericRepository<Empleado> empleadoRepository, IMapper mapper)
        {
            _empleadoRepository = empleadoRepository;
            _mapper = mapper;
        }

        public async Task<EmpleadoDTO> Create(EmpleadoDTO model)
        {
            try
            {
                Empleado crearEmpleado = await _empleadoRepository.Create(_mapper.Map<Empleado>(model));
                if (crearEmpleado.IdEmpleado == 0)
                {
                    throw new TaskCanceledException("Empleado no se pudo crear.");
                }
                return _mapper.Map<EmpleadoDTO>(crearEmpleado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(int idEmpleado)
        {
            try
            {
                Empleado buscarIdEmpleado = await _empleadoRepository.Obtain(e => e.IdEmpleado == idEmpleado) ?? throw new TaskCanceledException("Empleado no existe.");
                bool answer = await _empleadoRepository.Delete(buscarIdEmpleado);
                if (!answer)
                {
                    throw new TaskCanceledException("Empleado no se pudo eliminar.");
                }
                return answer;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Edit(EmpleadoDTO model)
        {
            try
            {
                Empleado empleadoModel = _mapper.Map<Empleado>(model);
                Empleado buscarEmpleado = await _empleadoRepository.Obtain(e => e.IdEmpleado == empleadoModel.IdEmpleado) ?? throw new TaskCanceledException("Empleado no existe.");
                buscarEmpleado.Nombres = empleadoModel.Nombres;
                buscarEmpleado.Apellidos = empleadoModel.Apellidos;
                buscarEmpleado.NumDocumento = empleadoModel.NumDocumento;
                buscarEmpleado.Activo = empleadoModel.Activo;
                bool answer = await _empleadoRepository.Edit(buscarEmpleado);
                if (!answer)
                {
                    throw new TaskCanceledException("Empleado no se puede modificar.");
                }
                return answer;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<EmpleadoDTO>> List()
        {
            try
            {
                IQueryable<Empleado> listarEmpleados = await _empleadoRepository.Consult();
                return _mapper.Map<List<EmpleadoDTO>>(listarEmpleados).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
