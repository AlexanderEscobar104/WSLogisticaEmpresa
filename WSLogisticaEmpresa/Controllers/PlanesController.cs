using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSLogisticaEmpresa.Models;
using WSLogisticaEmpresa.Services;

namespace WSLogisticaEmpresa.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlanesController : Controller
    {
        private readonly PlanesServices _PlanesService;

        public PlanesController(PlanesServices PlanesService)
        {
            _PlanesService = PlanesService;
        }

        /// <summary>
        /// metodo para listar Planes
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="IdPlanEntrega"></param>
        /// <param name="IdCliente"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("listPlanes")]
        public IActionResult listPlanes([FromQuery] int opcion, int IdPlanEntrega, string? IdCliente = "")
        {

            List<Planes> PlanesList = new List<Planes>();
            PlanesList = _PlanesService.GetAll(opcion, IdPlanEntrega, IdCliente);
            return Ok(PlanesList);
        }

        /// <summary>
        /// metodo para agregar Planes
        /// </summary>
        /// <param name="Planes"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addPlanes")]
        public IActionResult addPlanes(Planes Planes)
        {
            string resultado;
            resultado = _PlanesService.AddPlanes(Planes);
            return Ok(resultado);
        }

        /// <summary>
        /// metodo para actualizar Planes
        /// </summary>
        /// <param name="Planes"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updatePlanes")]
        public IActionResult updatePlanes(Planes Planes)
        {
            string resultado;
            resultado = _PlanesService.UpdatePlanes(Planes);
            return Ok(resultado);
        }

        /// <summary>
        /// metodo para eliminar Planes
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deletePlanes")]
        public IActionResult deletePlanes(int Id)
        {
            string resultado;
            resultado = _PlanesService.DeletePlanes(Id);
            return Ok(resultado);
        }
    }
}
