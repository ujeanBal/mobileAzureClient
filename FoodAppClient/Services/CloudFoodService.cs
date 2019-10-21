using System.Collections.Generic;
using System.Threading.Tasks;
using FoodAppClient.Models;
using Microsoft.WindowsAzure.MobileServices;

namespace FoodAppClient.Services
{
    public class CloudFoodService : IDataStore<Food>
    {
        private readonly MobileServiceClient _client;

        public CloudFoodService()
        {
            _client = new MobileServiceClient(App.BackendUrl);
        }

        public async Task<IEnumerable<Food>> GetItemsAsync(bool forceRefresh = false)
        {
            IMobileServiceTable<Food> todoTable = _client.GetTable<Food>();
            return await todoTable.ToEnumerableAsync();
        }

        public async Task<Food> GetItemAsync(string id)
        {
            if (id != null)
            {
                IMobileServiceTable<Food> todoTable = _client.GetTable<Food>();
                return await todoTable.LookupAsync(id);
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Food item)
        {
            if (item == null) return false;

            IMobileServiceTable<Food> todoTable = _client.GetTable<Food>();
            await todoTable.InsertAsync(item);

            return true;
        }

        public async Task<bool> UpdateItemAsync(Food item)
        {
            if (item == null || item.Id == null) return false;

            IMobileServiceTable<Food> todoTable = _client.GetTable<Food>();
            await todoTable.UpdateAsync(item);

            return true;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) return false;

            IMobileServiceTable<Food> todoTable = _client.GetTable<Food>();
            var item = await todoTable.LookupAsync(id);
            await todoTable.DeleteAsync(item);

            return true;
        }
    }
}
