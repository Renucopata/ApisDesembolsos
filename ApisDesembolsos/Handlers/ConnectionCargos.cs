namespace ApisDesembolsos.Handlers
{
    public class ConnectionCargos
    {

        private String cadConexion = String.Empty;
        public ConnectionCargos()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadConexion = builder.GetSection("ConnectionStrings:ConexionCargos").Value;
        }
        public String get_cadConexion()
        {
            return cadConexion;
        }
    }
}
