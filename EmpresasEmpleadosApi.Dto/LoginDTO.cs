using System.ComponentModel.DataAnnotations;

namespace EmpresasEmpleadosApi.Dto
{
    public class LoginDTO
    {
        [EmailAddress]
        [Required]
        public string? Correo { get; set; }
        public string? Clave { get; set; }
    }
}
