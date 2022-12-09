using NetMySql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMySql.Data.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehicles();
        Task<Vehicle> GetVehicleById(int id);
        Task<bool> InsertVehicle(Vehicle vehicle);
        Task<bool> UpdateVehicle(Vehicle vehicle);
        Task<bool> DeleteVehicle(Vehicle vehicle);
    }
}
