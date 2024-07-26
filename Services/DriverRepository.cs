using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComosCrud.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Azure.Cosmos;

namespace ComosCrud.Services
{
    public class DriverRepository : IDriverRepository
    {
        private readonly Container _container;
        public DriverRepository(
            string conn,
            string key,
            string databaseName,
            string containerName
        )
        {
            var cosmosClient = new CosmosClient(conn, key, new CosmosClientOptions { });
            _container = cosmosClient.GetContainer(databaseName, containerName);

        }

        public async Task<Driver> CreateDriverAsync(Driver driver)
        {

        }

        public async Task<Driver> DeleteDriverAsync(string id, string team)
        {
            throw new NotImplementedException();
        }

        public async Task<Driver> GetDriverAsync(string id, string team)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Driver>> GetDriversAsync()
        {
            var query = _container
            .GetItemQueryIterator<Driver>(new QueryDefinition("SELECT * FROM c"));
            var results = new List<Driver>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<Driver> UpdateDriveAsync(string id, Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}