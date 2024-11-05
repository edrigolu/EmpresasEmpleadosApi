namespace EmpresasEmpleadosApi.Entities.Models;

public partial class EmpleadoEmpresa
{
    public int IdEmpresaEmpleado { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdEmpresa { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual Empresa? IdEmpresaNavigation { get; set; }
}
