using LegacyMonopoly.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace LegacyMonopoly.IntegrationTests
{
    public class IntegrationTestBase
    {
        private const string DatabaseName = "Monopoly";

        protected static MonopolyContext GivenContext(bool beginTransaction = true)
        {
            var context = new MonopolyContext(new DbContextOptionsBuilder()
                .UseSqlServer(ApplicationDatabase.ConnectionString)
                .Options);
            if (beginTransaction)
                context.Database.BeginTransaction();
            return context;
        }

        private static SqlConnectionStringBuilder ApplicationDatabase =>
            new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                InitialCatalog = DatabaseName,
                IntegratedSecurity = true
            };
    }
}