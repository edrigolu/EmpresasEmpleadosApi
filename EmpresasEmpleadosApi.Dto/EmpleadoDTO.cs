namespace EmpresasEmpleadosApi.Dto
{
    public class EmpleadoDTO
    {
        public int IdEmpleado { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public int? NumDocumento { get; set; }
        public bool? Activo { get; set; }
    }
}
