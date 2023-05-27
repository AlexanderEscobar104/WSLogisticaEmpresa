using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WSLogisticaEmpresa.Connection
{
    public partial class ConnectionBd
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;

        public ConnectionBd()
        {
        }

        public static IConfiguration configuration { get; set; }

        public string GetConnectionString()
        {
            var buildes = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            configuration = buildes.Build();
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}
