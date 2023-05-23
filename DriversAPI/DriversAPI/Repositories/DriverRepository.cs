using DriversAPI.Helpers;
using DriversAPI.Models;
using System.Data.SqlClient;
using System.Data;

namespace DriversAPI.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private DataContext _context;

        public DriverRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Driver>> GetDrivers()
        {
            var driversList = new List<Driver>();

            await using SqlConnection connection = _context.CreateConnection();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT Id, FirstName, LastName, PhoneNumber, Email from dbo.Drivers " +
                                  "ORDER BY FirstName, LastName";
            var sqlDataAdapter = new SqlDataAdapter(command);
            var dtProducts = new DataTable();

            connection.Open();
            sqlDataAdapter.Fill(dtProducts);
            connection.Close();

            for (var index = 0; index < dtProducts.Rows.Count; index++)
            {
                var dr = dtProducts.Rows[index];
                driversList.Add(new Driver()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    FirstName = dr["FirstName"].ToString() ?? String.Empty,
                    LastName = dr["LastName"].ToString() ?? String.Empty,
                    PhoneNumber = dr["PhoneNumber"].ToString() ?? String.Empty,
                    Email = dr["Email"].ToString() ?? String.Empty
                });
            }

            return driversList;
        }

        public async Task<Driver> GetDriverById(int id)
        {
            await using SqlConnection connection = _context.CreateConnection();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText =
                $"SELECT Id, FirstName, LastName, PhoneNumber, Email from dbo.Drivers WHERE Id = {id}";
            var sqlDataAdapter = new SqlDataAdapter(command);
            var dtProducts = new DataTable();

            connection.Open();
            sqlDataAdapter.Fill(dtProducts);
            connection.Close();

            if (dtProducts.Rows.Count != 1)
            {
                return null;
            }

            var dr = dtProducts.Rows[0];
            var driver = new Driver()
            {
                Id = Convert.ToInt32(dr["Id"]),
                FirstName = dr["FirstName"].ToString() ?? String.Empty,
                LastName = dr["LastName"].ToString() ?? String.Empty,
                PhoneNumber = dr["PhoneNumber"].ToString() ?? String.Empty,
                Email = dr["Email"].ToString() ?? String.Empty
            };

            return driver;
        }

        public async Task<int> CreateDriver(Driver driver)
        {
            await using SqlConnection connection = _context.CreateConnection();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText =
                $"INSERT INTO dbo.Drivers(FirstName, LastName, PhoneNumber, Email) " +
                $"VALUES('{driver.FirstName}', '{driver.LastName}', '{driver.PhoneNumber}', '{driver.Email}')";

            connection.Open();
            int id = command.ExecuteNonQuery();
            connection.Close();

            return id;
        }

        public async Task<int> UpdateDriver(Driver driver)
        {
            await using SqlConnection connection = _context.CreateConnection();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText =
                $"UPDATE dbo.Drivers " +
                $"SET FirstName = '{driver.FirstName}', " +
                $"LastName = '{driver.LastName}', " +
                $"PhoneNumber = '{driver.PhoneNumber}', " +
                $"Email = '{driver.Email}'" +
                $"WHERE Id = '{driver.Id}'";

            connection.Open();
            int id = command.ExecuteNonQuery();
            connection.Close();

            return id;
        }

        public async Task<bool> DeleteDriver(int driverId)
        {
            await using SqlConnection connection = _context.CreateConnection();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText =
                $"DELETE from dbo.Drivers WHERE Id = {driverId}";

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }
    }
}
