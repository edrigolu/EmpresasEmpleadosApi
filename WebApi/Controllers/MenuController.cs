using EmpresasEmpleadosApi.Bussiness.Services.Interfaces;
using EmpresasEmpleadosApi.Dto;
using Microsoft.AspNetCore.Mvc;
using WebApi.Utility;

namespace WebApi.Controllers
{
    [Route("api/menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List(int idUsuario)
        {
            var respuesta = new Response<List<MenuDTO>>();
            try
            {
                respuesta.Status = true;
                respuesta.Value = await _menuService.List(idUsuario);
            }
            catch (Exception ex)
            {
                respuesta.Status = false;
                respuesta.Msg = ex.Message;
            }
            return Ok(respuesta);
        }
    }
}
