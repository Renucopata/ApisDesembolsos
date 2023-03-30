namespace ApisDesembolsos.Handlers
{
    public class ConnectionBuros
    {

        private String cadConexion = String.Empty;
        public ConnectionBuros()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadConexion = builder.GetSection("ConnectionStrings:ConexionBuros58").Value; //cadena cambiada de bdd a buros
        }
        public String get_cadConexionBuros()
        {
            return cadConexion;
        }
    }
}
