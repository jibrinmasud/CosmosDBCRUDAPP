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
            var response = await _container.CreateItemAsync(driver, new PartitionKey(driver.Team));
            return response.Resource;
        }

        public async Task<bool> DeleteDriver(string id, string team)
        {
            var response = await _container.DeleteItemAsync<Driver>(id, new PartitionKey(team));
            if (response.Resource != null)
                return true;
            return false;
        }

        public async Task<Driver> GetDriverAsync(string id, string team)
        {
            try
            {
                var response = await _container.ReadItemAsync<Driver>(id, new PartitionKey(team));
                return response;

            }
            catch (Exception ex)
            {
                return null;
            }
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
            var response = await _container.UpsertItemAsync(driver, new PartitionKey(driver.Team));
            return response.Resource;
        }
    }
}