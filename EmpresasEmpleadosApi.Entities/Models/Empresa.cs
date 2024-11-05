namespace EmpresasEmpleadosApi.Entities.Models;

public partial class Empresa
{
    public int IdEmpresa { get; set; }

    public string? NombreEmpresa { get; set; }

    public bool? Activa { get; set; }

    public virtual ICollection<EmpresaEmpleado> DetalleEmpresa { get; set; } = new List<EmpresaEmpleado>();
}
