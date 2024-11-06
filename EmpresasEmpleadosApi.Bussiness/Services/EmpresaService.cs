using AutoMapper;
using EmpresasEmpleadosApi.Bussiness.Services.Interfaces;
using EmpresasEmpleadosApi.Data.Repository.Interface;
using EmpresasEmpleadosApi.Dto;
using EmpresasEmpleadosApi.Entities.Models;

namespace EmpresasEmpleadosApi.Bussiness.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IGenericRepository<Empresa> _empresaRepository;
        private readonly IGenericRepository<EmpresaEmpleado> _genericRepository;
        private readonly IMapper _mapper;

        public EmpresaService(IGenericRepository<Empresa> empresaRepository, IGenericRepository<EmpresaEmpleado> genericRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<EmpresaDTO> Create(EmpresaDTO model)
        {
            try
            {
                Empresa crearEmpresa = await _empresaRepository.Create(_mapper.Map<Empresa>(model));
                if (crearEmpresa.IdEmpresa == 0)
                {
                    throw new TaskCanceledException("Empresa no se pudo crear.");
                }
                return _mapper.Map<EmpresaDTO>(crearEmpresa);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(int idEmpresa)
        {
            try
            {
                Empresa buscarIdEmpresa = await _empresaRepository.Obtain(e => e.IdEmpresa == idEmpresa);
                if (buscarIdEmpresa == null)
                {
                    throw new TaskCanceledException("Empresa no existe.");
                }
                bool answer = await _empresaRepository.Delete(buscarIdEmpresa);
                if (!answer)
                {
                    throw new TaskCanceledException("Empresa no se pudo eliminar.");
                }
                return answer;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Edit(EmpresaDTO model)
        {
            try
            {
                Empresa empresaModel = _mapper.Map<Empresa>(model);
                Empresa buscarEmpresa = await _empresaRepository.Obtain(e => e.IdEmpresa == empresaModel.IdEmpresa) ?? throw new TaskCanceledException("Empresa no existe.");
                buscarEmpresa.NombreEmpresa = empresaModel.NombreEmpresa;
                buscarEmpresa.Activa = empresaModel.Activa;
                bool answer = await _empresaRepository.Edit(buscarEmpresa);
                if (!answer)
                {
                    throw new TaskCanceledException("Empresa no se puede modificar.");
                }
                return answer;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<EmpresaDTO>> List()
        {
            try
            {
                IQueryable<Empresa> listarEmpresas = await _empresaRepository.Consult();
                return _mapper.Map<List<EmpresaDTO>>(listarEmpresas).ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmpresaEmpleadoDTO> Register(EmpresaEmpleadoDTO model)
        {
            try
            {
                EmpresaEmpleado registrar = await _genericRepository.Create(_mapper.Map<EmpresaEmpleado>(model));
                if (registrar.IdEmpresa == 0)
                {
                    throw new TaskCanceledException("Empresa y el empleado no se pudieron registrar.");
                }
                return _mapper.Map<EmpresaEmpleadoDTO>(registrar);
            }
            catch
            {
                throw;
            }
        }
    }
}
