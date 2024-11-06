using EmpresasEmpleadosApi.Bussiness.Services.Interfaces;
using EmpresasEmpleadosApi.Dto;
using Microsoft.AspNetCore.Mvc;
using WebApi.Utility;

namespace WebApi.Controllers
{
    [Route("api/empleados")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var rsp = new Response<List<EmpleadoDTO>>();
            try
            {
                rsp.Status = true;
                rsp.Value = await _empleadoService.List();
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
        public async Task<IActionResult> Create([FromBody] EmpleadoDTO empleado)
        {
            var rsp = new Response<EmpleadoDTO>();
            try
            {
                rsp.Status = true;
                rsp.Value = await _empleadoService.Create(empleado);
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
        public async Task<IActionResult> Edit([FromBody] EmpleadoDTO empleado)
        {
            var rsp = new Response<bool>();
            try
            {
                rsp.Status = true;
                rsp.Value = await _empleadoService.Edit(empleado);
            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpDelete]
        [Route("Delete/{idEmpresa:int}")]
        public async Task<IActionResult> Delete(int idEmpresa)
        {
            var rsp = new Response<bool>();
            try
            {
                rsp.Status = true;
                rsp.Value = await _empleadoService.Delete(idEmpresa);
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
