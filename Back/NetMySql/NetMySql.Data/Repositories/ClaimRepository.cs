using Dapper;
using MySql.Data.MySqlClient;
using NetMySql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMySql.Data.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public ClaimRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteClaim(Claim claim)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM claim WHERE idclaim = @Idclaim ";
            var result = await db.ExecuteAsync(sql, new { IdClaim = claim.IdClaim });
            return result > 0;
        }

        public async Task<IEnumerable<Claim>> GetAllClaims()
        {
            var db = dbConnection();
            var sql = @" SELECT idclaim, description, status, idvehicle 
                        FROM claim";
            return await db.QueryAsync<Claim>(sql, new { });
        }

        public async Task<Claim> GetClaimById(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT idclaim, description, status, idvehicle 
                        FROM claim 
                        WHERE idclaim = @Id";
            return await db.QueryFirstOrDefaultAsync<Claim>(sql, new { });
        }

        public async Task<bool> InsertClaim(Claim claim)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO claim(idclaim, description, status, idvehicle)
                        VALUES(@Idclaim, @Description, @Status, @Idvehicle) ";
            var result = await db.ExecuteAsync(sql, new
                { claim.IdClaim, claim.Description, claim.Status, claim.IdVehicle });
            return result > 0;
        }

        public async Task<bool> UpdateClaim(Claim claim)
        {
            var db = dbConnection();
            var sql = @" UPDATE claim
                         SET idclaim = @Idclaim, 
                             description = @Description, 
                             status = @Status, 
                             idvehicle = @Idvehicle";
            var result = await db.ExecuteAsync(sql, new
            { claim.IdClaim, claim.Description, claim.Status, claim.IdVehicle });
            return result > 0;
        }
    }
}