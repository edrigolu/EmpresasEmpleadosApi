using System;
using System.Collections.Generic;

namespace EmpresasEmpleadosApi.Entities.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? RolDescripcion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
