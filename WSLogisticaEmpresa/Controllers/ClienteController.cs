using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WSLogisticaEmpresa.Models;
using WSLogisticaEmpresa.Services;

namespace WSLogisticaEmpresa.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly ClientesServices _ClientesService;

        public ClienteController(ClientesServices ClientesService)
        {
            _ClientesService = ClientesService;
        }

        /// <summary>
        /// metodo para listar Clientes
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="IdCliente"></param>
        /// <param name="Identificacion"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("listClientes")]
        public IActionResult listClientes(int opcion, int IdCliente, string? Identificacion = "")
        {

            List<Clientes> ClientesList = new List<Clientes>();
            ClientesList = _ClientesService.GetAll(opcion, IdCliente, Identificacion);
            return Ok(ClientesList);
        }

        /// <summary>
        /// metodo para agregar Clientes
        /// </summary>
        /// <param name="Clientes"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addClientes")]
        public IActionResult addClientes(Clientes Clientes)
        {
            Clientes resultado;
            resultado = _ClientesService.AddClientes(Clientes);
            return Ok(resultado);
        }

        /// <summary>
        /// metodo para actualizar Clientes
        /// </summary>
        /// <param name="Clientes"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateClientes")]
        public IActionResult updateClientes(Clientes Clientes)
        {
            Clientes resultado;
            resultado = _ClientesService.UpdateClientes(Clientes);
            return Ok(resultado);
        }

        /// <summary>
        /// metodo para eliminar Clientes
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteClientes")]
        public IActionResult deleteClientes(int Id)
        {
            Clientes resultado;
            resultado = _ClientesService.DeleteClientes(Id);
            return Ok(resultado);
        }
    }
}
