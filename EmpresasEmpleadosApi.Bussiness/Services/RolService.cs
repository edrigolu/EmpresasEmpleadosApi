using AutoMapper;
using EmpresasEmpleadosApi.Bussiness.Services.Interfaces;
using EmpresasEmpleadosApi.Data.Repository.Interface;
using EmpresasEmpleadosApi.Dto;
using EmpresasEmpleadosApi.Entities.Models;

namespace EmpresasEmpleadosApi.Bussiness.Services
{
    public class RolService : IRolService
    {
        private readonly IGenericRepository<Rol> _rolRepository;
        private readonly IMapper _mapper;

        public RolService(IGenericRepository<Rol> rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        public async Task<List<RolDTO>> List()
        {
            try
            {
                IQueryable<Rol> listRole = await _rolRepository.Consult();
                return _mapper.Map<List<RolDTO>>(listRole).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
