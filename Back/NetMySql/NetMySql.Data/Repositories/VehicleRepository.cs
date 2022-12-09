using Dapper;
using MySql.Data.MySqlClient;
using NetMySql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NetMySql.Data.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public VehicleRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteVehicle(Vehicle vehicle)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM vehicle WHERE idvehicle = @Idvehicle";
            var result = await db.ExecuteAsync(sql, new { IdVehicle= vehicle.IdVehicle});
            return result > 0;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            var db = dbConnection();
            var sql = @" SELECT idvehicle, brand, vin, color, year, idowner
                        FROM vehicle";
            return await db.QueryAsync<Vehicle>(sql, new { });
        }

        public async Task<Vehicle> GetVehicleById(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT idvehicle, brand, vin, color, year, idowner
                        FROM vehicle 
                        WHERE idvehicle = @Id";
            return await db.QueryFirstOrDefaultAsync<Vehicle>(sql, new { });
        }

        public async Task<bool> InsertVehicle(Vehicle vehicle)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO vehicle(brand, vin, color, year, idowner)
                        VALUES( @Brand, @Vin, @Color, @Year,@Idowner) ";
            var result = await db.ExecuteAsync(sql, new
            { vehicle.Brand, vehicle.Vin, vehicle.Color, vehicle.Year, vehicle.IdOwner});
            return result > 0;
        }

        public async Task<bool> UpdateVehicle(Vehicle vehicle)
        {
            var db = dbConnection();
            var sql = @" UPDATE vehicle
                         SET idvehicle = @Idvehicle, 
                             brand = @Brand, 
                             vin = @Vin,
                             color = @Color,
                             year = @Year,
                             idowner= @Idowner";
            var result = await db.ExecuteAsync(sql, new
            { vehicle.IdVehicle, vehicle.Brand, vehicle.Vin, vehicle.Color, vehicle.Year, vehicle.IdOwner });
            return result > 0;
        }
    }
}
