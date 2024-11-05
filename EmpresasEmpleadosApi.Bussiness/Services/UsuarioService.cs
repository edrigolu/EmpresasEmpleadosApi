using AutoMapper;
using EmpresasEmpleadosApi.Bussiness.Services.Interfaces;
using EmpresasEmpleadosApi.Data.Repository.Interface;
using EmpresasEmpleadosApi.Dto;
using EmpresasEmpleadosApi.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpresasEmpleadosApi.Bussiness.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _userRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IGenericRepository<Usuario> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Borrar(int idUsuario)
        {
            try
            {
                Usuario encontrarUsuario = await _userRepository.Obtain(u => u.IdUsuario == idUsuario);
                if (encontrarUsuario == null)
                {
                    throw new TaskCanceledException("Usuario no existe.");
                }
                bool answer = await _userRepository.Delete(encontrarUsuario);
                if (!answer)
                {
                    throw new TaskCanceledException("Usuario no se pudo eliminar.");
                }
                return answer;
            }
            catch
            {
                throw;
            }
        }

        public async Task<UsuarioDTO> Crear(UsuarioDTO model)
        {
            try
            {
                Usuario crearUsuario = await _userRepository.Create(_mapper.Map<Usuario>(model));
                if (crearUsuario.IdUsuario == 0)
                {
                    throw new TaskCanceledException("Usuario no se pudo crear.");
                }
                IQueryable<Usuario> query = await _userRepository.Consult(u => u.IdUsuario == crearUsuario.IdUsuario);
                crearUsuario = query.Include(rol => rol.IdRolNavigation).First();
                return _mapper.Map<UsuarioDTO>(crearUsuario);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(UsuarioDTO model)
        {
            try
            {
                Usuario usuarioModel = _mapper.Map<Usuario>(model);
                Usuario buscarUsuario = await _userRepository.Obtain(u => u.IdUsuario == usuarioModel.IdUsuario);
                if (buscarUsuario == null)
                {
                    throw new TaskCanceledException("Usuario no existe.");
                }
                buscarUsuario.Nombre = usuarioModel.Nombre;
                buscarUsuario.Apellidos = usuarioModel.Apellidos;
                buscarUsuario.Correo = usuarioModel.Correo;
                buscarUsuario.IdRol = usuarioModel.IdRol;
                buscarUsuario.Clave = usuarioModel.Clave;
                buscarUsuario.Activo = usuarioModel.Activo;
                bool answer = await _userRepository.Edit(buscarUsuario);
                if (!answer)
                {
                    throw new TaskCanceledException("Usuario no se pudo modificar.");
                }
                return answer;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<UsuarioDTO>> ListarUsuarios()
        {
            try
            {
                IQueryable<Usuario> queryUser = await _userRepository.Consult();
                List<Usuario> listUser = queryUser.Include(rol => rol.IdRolNavigation).ToList();
                return _mapper.Map<List<UsuarioDTO>>(listUser);
            }
            catch
            {
                throw;
            }
        }

        public async Task<SessionDTO> ValidarCredenciales(string correo, string clave)
        {
            try
            {
                IQueryable<Usuario> queryUser = await _userRepository.Consult(u => u.Correo == correo && u.Clave == clave);
                if (queryUser.FirstOrDefault() == null)
                {
                    throw new TaskCanceledException("Usuario no existe.");
                }
                Usuario backUser = queryUser.Include(rol => rol.IdRolNavigation).First();
                return _mapper.Map<SessionDTO>(backUser);
            }
            catch
            {
                throw;
            }
        }
    }
}
