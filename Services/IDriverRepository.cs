using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComosCrud.Models;

namespace ComosCrud.Services
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> GetDriversAsync();
        Task<Driver> GetDriverAsync(string id, string team);
        Task<Driver> CreateDriverAsync(Driver driver);
        Task<Driver> UpdateDriveAsync(string id, Driver driver);
        Task<bool> DeleteDriver(string id, string team);
    }
}