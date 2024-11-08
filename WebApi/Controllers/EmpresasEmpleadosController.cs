using EmpresasEmpleadosApi.Bussiness.Services;
using EmpresasEmpleadosApi.Bussiness.Services.Interfaces;
using EmpresasEmpleadosApi.Dto;
using Microsoft.AspNetCore.Mvc;
using WebApi.Utility;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasEmpleadosController : ControllerBase
    {
        private readonly IEmpresaEmpleadoService _empresaEmpleadoService;

        public EmpresasEmpleadosController(IEmpresaEmpleadoService empresaEmpleadoService)
        {
            _empresaEmpleadoService = empresaEmpleadoService;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] EmpresaEmpleadoDTO empresaEmpleadoDTO)
        {
            var rsp = new Response<EmpresaEmpleadoDTO>();
            try
            {
                rsp.Status = true;
                rsp.Value = await _empresaEmpleadoService.Register(empresaEmpleadoDTO);
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
