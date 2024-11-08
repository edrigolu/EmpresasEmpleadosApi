using EmpresasEmpleadosApi.Bussiness.Services.Interfaces;
using EmpresasEmpleadosApi.Dto;
using EmpresasEmpleadosApi.Utilities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Utility;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly Utilidades _utilidades;

        public UsuariosController(IUsuarioService usuarioService, Utilidades utilidades)
        {
            _usuarioService = usuarioService;
            _utilidades = utilidades;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var rsp = new Response<List<UsuarioDTO>>();
            try
            {
                rsp.Status = true;
                rsp.Value = await _usuarioService.List();
            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] UsuarioDTO usuario)
        {
            var rsp = new Response<UsuarioDTO>();
            var usuarioDTO= new UsuarioDTO
            {
                Nombre = usuario.Nombre,
                Apellidos = usuario.Apellidos,
                Correo = usuario.Correo,
                Clave = _utilidades.EncriptarSHA256(usuario.Clave!),
                IdRol=usuario.IdRol,
                Activo=1
            };
            
            try
            {
                rsp.Status = true;
                rsp.Value = await _usuarioService.Create(usuarioDTO);
            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] UsuarioDTO usuario)
        {
            var rsp = new Response<bool>();
            try
            {
                rsp.Status = true;
                rsp.Value = await _usuarioService.Edit(usuario);
            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpDelete]
        [Route("Delete/{idUsuario:int}")]
        public async Task<IActionResult> Delete(int idUsuario)
        {
            var rsp = new Response<bool>();
            try
            {
                rsp.Status = true;
                rsp.Value = await _usuarioService.Delete(idUsuario);
            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var rsp = new Response<SessionDTO>();
            try
            {
                rsp.Status = true;
                rsp.Value = await _usuarioService.ValidateCredentials(login.Correo!, login.Clave!);
            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            return Ok(rsp);
        }


    }
}
