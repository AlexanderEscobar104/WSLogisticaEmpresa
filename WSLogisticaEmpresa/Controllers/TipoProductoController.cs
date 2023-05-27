using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSLogisticaEmpresa.Models;
using WSLogisticaEmpresa.Services;

namespace WSLogisticaEmpresa.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProductosController : Controller
    {
        private readonly TipoProductoServices _TipoProductosService;

        public TipoProductosController(TipoProductoServices TipoProductosService)
        {
            _TipoProductosService = TipoProductosService;
        }
        /// <summary>
        /// metodo para listar TipoProductos
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="IdTipoProducto"></param>
        /// <param name="TipoProducto"></param>
        /// <param name="TipoLogistica"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("listTipoProductos")]
        public IActionResult listTipoProductos([FromQuery] int opcion, int IdTipoProducto, string? TipoProducto = "", string? TipoLogistica = "")
        {

            List<TipoProductos> TipoProductosList = new List<TipoProductos>();
            TipoProductosList = _TipoProductosService.GetAll(opcion, IdTipoProducto, TipoProducto, TipoLogistica);
            return Ok(TipoProductosList);
        }

        /// <summary>
        /// metodo para agregar TipoProductos
        /// </summary>
        /// <param name="TipoProductos"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addTipoProductos")]
        public IActionResult addTipoProductos(TipoProductos TipoProductos)
        {
            string resultado;
            resultado = _TipoProductosService.AddTipoProductos(TipoProductos);
            return Ok(resultado);
        }

        /// <summary>
        /// metodo para actualizar TipoProductos
        /// </summary>
        /// <param name="TipoProductos"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateTipoProductos")]
        public IActionResult updateTipoProductos(TipoProductos TipoProductos)
        {
            string resultado;
            resultado = _TipoProductosService.UpdateTipoProductos(TipoProductos);
            return Ok(resultado);
        }

        /// <summary>
        /// metodo para eliminar TipoProductos
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteTipoProductos")]
        public IActionResult deleteTipoProductos(int Id)
        {
            string resultado;
            resultado = _TipoProductosService.DeleteTipoProductos(Id);
            return Ok(resultado);
        }
    }
}
