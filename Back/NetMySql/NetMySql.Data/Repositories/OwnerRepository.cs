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
    public class OwnerRepository : IOwnerRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public OwnerRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteOwner(Owner owner)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM owner WHERE idowner= @Idowner ";
            var result = await db.ExecuteAsync(sql, new { IdOwner = owner.IdOwner });
            return result > 0;
        }

        public async Task<IEnumerable<Owner>> GetAllOwners()
        {
            var db = dbConnection();
            var sql = @" SELECT idowner, firstname, lastname, driverlincese
                        FROM owner";
            return await db.QueryAsync<Owner>(sql, new { });
        }

        public async Task<Owner> GetOwnerById(int id)
        {
            var db = dbConnection();
            var sql = @" SELECT idowner, firstname, lastname, driverlincese
                        FROM owner";
            return await db.QueryFirstOrDefaultAsync<Owner>(sql, new { });
        }

        public async Task<bool> InsertOwner(Owner owner)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO owner(idowner, firstname, lastname, driverlincese)
                        VALUES(@Idowner, @Firstname, @Lastname, @Driverlincese) ";
            var result = await db.ExecuteAsync(sql, new
            { owner.IdOwner, owner.FirstName, owner.LastName, owner.DriverLincese});
            return result > 0;
        }

        public async Task<bool> UpdateOwner(Owner owner)
        {
            var db = dbConnection();
            var sql = @" UPDATE owner
                         SET idowner = @Idowner, 
                             firstname = @Firstname, 
                             lastname = @Lastname, 
                             driverlincese = @Driverlincese";
            var result = await db.ExecuteAsync(sql, new
            { owner.IdOwner, owner.FirstName, owner.LastName, owner.DriverLincese});
            return result > 0;
        }
    }
}
