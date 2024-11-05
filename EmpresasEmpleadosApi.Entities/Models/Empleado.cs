using System;
using System.Collections.Generic;

namespace EmpresasEmpleadosApi.Entities.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public int? NumDocumento { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<EmpresaEmpleado> EmpresaEmpleados { get; set; } = new List<EmpresaEmpleado>();
}
