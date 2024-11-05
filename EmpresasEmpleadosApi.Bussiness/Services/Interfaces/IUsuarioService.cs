using EmpresasEmpleadosApi.Dto;

namespace EmpresasEmpleadosApi.Bussiness.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> ListarUsuarios();
        Task<SessionDTO> ValidarCredenciales(string correo, string clave);
        Task<UsuarioDTO> Crear(UsuarioDTO model);
        Task<bool> Editar(UsuarioDTO model);
        Task<bool> Borrar(int idUsuario);
    }
}
