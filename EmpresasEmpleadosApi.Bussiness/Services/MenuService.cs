using AutoMapper;
using EmpresasEmpleadosApi.Bussiness.Services.Interfaces;
using EmpresasEmpleadosApi.Data.Repository.Interface;
using EmpresasEmpleadosApi.Dto;
using EmpresasEmpleadosApi.Entities.Models;

namespace EmpresasEmpleadosApi.Bussiness.Services
{
    public class MenuService : IMenuService
    {
        private readonly IGenericRepository<Usuario> _usuarioRepository;
        private readonly IGenericRepository<MenuRol> _menuRolRepository;
        private readonly IGenericRepository<Menu> _menuRepository;
        private readonly IMapper _mapper;

        public MenuService(IGenericRepository<Usuario> usuarioRepository,
                           IGenericRepository<MenuRol> menuRolRepository,
                           IGenericRepository<Menu> menuRepository,
                           IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _menuRolRepository = menuRolRepository;
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task<List<MenuDTO>> List(int idUsuario)
        {
            IQueryable<Usuario> userTable = await _usuarioRepository.Consult(u => u.IdUsuario == idUsuario);
            IQueryable<MenuRol> menuRolsTable = await _menuRolRepository.Consult();
            IQueryable<Menu> menuTable = await _menuRepository.Consult();
            try
            {
                IQueryable<Menu> resulTable = (from u in userTable
                                               join mr in menuRolsTable on u.IdRol equals mr.IdRol
                                               join m in menuTable on mr.IdMenu equals m.IdMenu
                                               select m).AsQueryable();
                List<Menu> menuList = resulTable.ToList();
                return _mapper.Map<List<MenuDTO>>(menuList);
            }
            catch
            {
                throw;
            }
        }
    }
}
