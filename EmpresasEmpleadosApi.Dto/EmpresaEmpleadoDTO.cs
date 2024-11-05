namespace EmpresasEmpleadosApi.Dto
{
    public class EmpresaEmpleadoDTO
    {
        public int IdEmpresaEmpleado { get; set; }
        public int? IdEmpresa { get; set; }
        public string? NombreEmpresa { get; set; }
        public int? IdEmpleado { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public int EstadoRegistro { get; set; }

    }
}
