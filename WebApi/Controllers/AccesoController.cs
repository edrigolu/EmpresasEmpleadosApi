using EmpresasEmpleadosApi.Data.DBContext;
using EmpresasEmpleadosApi.Dto;
using EmpresasEmpleadosApi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/acceso")]
    [AllowAnonymous]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly EmpresaEmpleadosDbContext _dbContext;
       
        private readonly Utilidades _utilidades;

        public AccesoController(EmpresaEmpleadosDbContext dbContext, Utilidades utilidades)
        {
            _dbContext = dbContext;          
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO objeto)
        {
            var usuarioEncontrado = await _dbContext.Usuarios
                                                    .Where(u =>
                                                        u.Correo == objeto.Correo &&
                                                        u.Clave == _utilidades.EncriptarSHA256(objeto.Clave!)
                                                      ).FirstOrDefaultAsync();

            return usuarioEncontrado == null
                ? (IActionResult)StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" })
                : StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilidades.GenerarJWT(usuarioEncontrado) });
        }



    }
}
