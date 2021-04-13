using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Ecommerce.Infra
{
    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; }
        public IConfiguration Configuration { get; }
        public string HangfireConnectionString { get; set; }
        public string Host { get; set; }

        public DatabaseConfiguration(IConfiguration configuration)
        {
            var connectioString = configuration.GetConnectionString("Postgres");

            if (string.IsNullOrWhiteSpace(connectioString))
            {
                throw new ArgumentNullException($"Invalid ConnectionString:Postgres configuration value");
            }

            var defaultConnectioString = new NpgsqlConnectionStringBuilder(connectioString)
            {
                ApplicationName = "Ecommerce"
            };

            ConnectionString = defaultConnectioString.ToString();

            var hangfireConnectioString = new NpgsqlConnectionStringBuilder(connectioString)
            {
                ApplicationName = "Ecommerce.Hangfire"
            };

            HangfireConnectionString = hangfireConnectioString.ToString();

            Host = defaultConnectioString.Host;

            Configuration = configuration;
        }

        public static DatabaseConfiguration LoadDevelopmentConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            return new DatabaseConfiguration(configuration);
        }
    }
}

