using System;
using System.Collections.Generic;

namespace EmpresasEmpleadosApi.Entities.Models;

public partial class Empresa
{
    public int IdEmpresa { get; set; }

    public string? NombreEmpresa { get; set; }

    public virtual ICollection<EmpleadoEmpresa> EmpleadoEmpresas { get; set; } = new List<EmpleadoEmpresa>();
}
