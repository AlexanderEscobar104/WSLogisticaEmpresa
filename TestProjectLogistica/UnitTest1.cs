using WSLogisticaEmpresa.Models;
using WSLogisticaEmpresa.Services;

namespace TestProjectLogistica
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// prueba unitaria para la cracion de planes
        /// </summary>
        [TestMethod]
        public void TestCreatePlanes()
        {
            DateTime thisDay = DateTime.Today;
            Planes planes = new Planes();
            PlanesServices planesServices = new PlanesServices();
            planes.Descuento = 500;
            planes.NumeroFlota = "YYE4567T";
            planes.Placa = "";
            planes.Nombres = "";
            planes.TipoProducto = "";
            planes.TipoLogistica = "Maritima";
            planes.IdCliente = 2;
            planes.IdTipoProducto = 2;
            planes.Cantidad = 50;
            planes.FechaRegistro = thisDay;
            planes.FechaEntrega = thisDay;
            planes.PuertoEnvio = "Colombia";
            planes.PrecioEnvio = 500000;
            planes.NumeroGuia = "5567788999";

            Planes resultado = new Planes();
            resultado = planesServices.AddPlanes(planes);
            Assert.AreEqual(18, resultado.IdPlanEntrega);

        }

        /// <summary>
        /// prueba unitaria para la actualizacion de planes
        /// </summary>
        [TestMethod]
        public void TestUpdatePlanes()
        {
            DateTime thisDay = DateTime.Today;
            Planes planes = new Planes();
            PlanesServices planesServices = new PlanesServices();
            planes.IdPlanEntrega = 10;
            planes.Descuento = 500;
            planes.NumeroFlota = "JJE4567T";
            planes.Placa = "";
            planes.Nombres = "";
            planes.TipoProducto = "";
            planes.TipoLogistica = "Maritima";
            planes.IdCliente = 2;
            planes.IdTipoProducto = 2;
            planes.Cantidad = 50;
            planes.FechaRegistro = thisDay;
            planes.FechaEntrega = thisDay;
            planes.PuertoEnvio = "Huila";
            planes.PrecioEnvio = 500000;
            planes.NumeroGuia = "5567788999";

            Planes resultado;
            resultado = planesServices.UpdatePlanes(planes);
            Assert.AreEqual(10, resultado.IdPlanEntrega);

        }

        /// <summary>
        /// prueba unitaria para la eliminacion de planes
        /// </summary>
        [TestMethod]
        public void TestDeletePlanes()
        {
            Planes planes = new Planes();
            PlanesServices planesServices = new PlanesServices();
            planes.IdPlanEntrega = 12;

            Planes resultado;
            resultado = planesServices.DeletePlanes(12);
            Assert.AreEqual(12, resultado.IdPlanEntrega);

        }
    }
}