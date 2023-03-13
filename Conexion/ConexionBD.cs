namespace CentralOpticAPI.Conexion
{
    public class ConexionBD
    {
        private string connectionString = string.Empty;
        public ConexionBD()
        {

            var constructor = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            connectionString = constructor.GetSection("ConnectionStrings:conexionmaestra").Value;

        }
        public string cadenaSQL()
        {
            return connectionString;
        }
    }
}
