namespace ApisDesembolsos.Handlers
{
    public class ConnectionDesembolsos
    {
        private String cadConexion = String.Empty;
        public ConnectionDesembolsos()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadConexion = builder.GetSection("ConnectionStrings:ConexionBDD").Value; //cadena cambiada de bdd a buros
        }
        public String get_cadConexion()
        {
            return cadConexion;
        }
    }
}
