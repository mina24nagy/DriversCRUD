using System.Data;
using System.Data.SqlClient;

namespace DriversAPI.Helpers
{
    public class DataContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task Init()
        {
            await _createDriversTableIfNotExists();
            async Task _createDriversTableIfNotExists()
            {
                await using var connection = CreateConnection();
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText =
                    $"IF NOT EXISTS (SELECT * FROM sys.tables t JOIN sys.schemas s ON (t.schema_id = s.schema_id) " +
                    $"WHERE s.name = 'dbo' AND t.name = 'Drivers') " +
                    $"CREATE TABLE [dbo].[Drivers]" +
                    $"([Id] [bigint] IDENTITY(1,1) NOT NULL, " +
                    $"[FirstName] NVARCHAR(500) NOT NULL, " +
                    $"[LastName] NVARCHAR(500) NOT NULL, " +
                    $"[PhoneNumber] [nvarchar](50) NULL, " +
                    $"[Email] [nvarchar](200) NULL " +
                    $"CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED ([Id] ASC) " +
                    $"WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, " +
                    $"ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]";

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
