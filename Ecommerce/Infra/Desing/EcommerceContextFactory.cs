using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Desing
{
    public class QgraosContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DataContext>();

            var databaseConfiguration = DatabaseConfiguration.LoadDevelopmentConfiguration();

            builder.UseNpgsql(databaseConfiguration.ConnectionString);

            return new DataContext(builder.Options);
        }
    }
}
