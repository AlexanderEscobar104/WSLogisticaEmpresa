namespace WSLogisticaEmpresa.Models
{
    public class Planes
    {
        public int IdPlanEntrega { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string PuertoEnvio { get; set; }
        public int PrecioEnvio { get; set; }
        public int Descuento { get; set; }
        public string NumeroFlota { get; set; }
        public string NumeroGuia { get; set; }
        public string TipoLogistica { get; set; }
        public string Placa { get; set; }
    }
}
