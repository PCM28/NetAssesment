using NetMySql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMySql.Data.Repositories
{
    public interface IClaimRepository
    {
        Task<IEnumerable<Claim>> GetAllClaims();
        Task<Claim> GetClaimById(int id);
        Task<bool> InsertClaim(Claim claim);
        Task<bool> UpdateClaim(Claim claim);
        Task<bool> DeleteClaim(Claim claim);
    }
}
