using EmpresasEmpleadosApi.Dto;

namespace EmpresasEmpleadosApi.Bussiness.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> List();
        Task<LoginDTO> ValidateCredentials(string correo, string clave);
        Task<UsuarioDTO> Create(UsuarioDTO model);
        Task<bool> Edit(UsuarioDTO model);
        Task<bool> Delete(int idUsuario);
    }
}
