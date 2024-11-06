namespace EmpresasEmpleadosApi.Dto
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Correo { get; set; }
        public int IdRol { get; set; }        
        public string? Clave { get; set; }
        public int Activo { get; set; }
    }
}
