using Microsoft.Extensions.Configuration;

namespace ContactListApi.Db
{
    public class Connection
    {
        private readonly string _connectionString;

        public Connection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Db");
        }

        public static string connRute
        {
            get
            {
                var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                var connection = new Connection(config);

                return connection._connectionString;
            }
        }
    }
}