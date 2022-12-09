using NetMySql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMySql.Data.Repositories
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllOwners();
        Task<Owner> GetOwnerById(int id);
        Task<bool> InsertOwner(Owner owner);
        Task<bool> UpdateOwner(Owner owner);
        Task<bool> DeleteOwner(Owner owner);
    }
}
