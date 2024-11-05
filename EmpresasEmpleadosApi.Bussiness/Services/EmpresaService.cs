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
        private readonly IMapper _mapper;

        public EmpresaService(IGenericRepository<Empresa> empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public async Task<EmpresaDTO> Crear(EmpresaDTO model)
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

        public async Task<bool> Borrar(int idEmpresa)
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

        public async Task<bool> Editar(EmpresaDTO model)
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

        public async Task<List<EmpresaDTO>> ListarEmpresas()
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
    }
}
