using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace OneAppHNI.EntityFrameworkCore
{
    public static class OneAppHNIDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<OneAppHNIDbContext> builder, string connectionString)
        {
            builder.UseOracle(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<OneAppHNIDbContext> builder, DbConnection connection)
        {
            builder.UseOracle(connection);
        }
    }
}
