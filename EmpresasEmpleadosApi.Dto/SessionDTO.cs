namespace EmpresasEmpleadosApi.Dto
{
    public class SessionDTO
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Correo { get; set; }
        public string? RolDescripcion { get; set; }
    }
}
