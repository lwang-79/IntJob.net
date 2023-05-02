using System;
using Microsoft.Extensions.Configuration;
using Utils.Log;
using IntJob.DataAccess.Data;
using IntJob.DataAccess.Models;
using IntJob.DataAccess.DbAccess;

namespace IntJob.Maui
{
	public class DataStore<TModel, TData> where TData : class, IModelData<TModel>
	{
        private TData _modelData;

        public DataStore(IConfiguration config)
		{
            SqliteDataAccess sqliteDataAccess = new SqliteDataAccess(config);
            _modelData = Activator.CreateInstance(typeof(TData), sqliteDataAccess) as TData;
        }

        public async Task<TModel> Get(int id)
        {
            try
            {
                return await _modelData.Get(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.WriteWithTime($"Failed to get the item: {ex.Message}");
                return default(TModel);
            }
        }

        public async Task<IEnumerable<TModel>> List()
        {
            try
            {
                return await _modelData.List();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.WriteWithTime($"Failed to list items: {ex.Message}");
                return new List<TModel>();
            }
        }

        public async Task<TModel> Create(TModel item)
        {
            try
            {
                return await _modelData.Create(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.WriteWithTime($"Failed to create the item: {ex.Message}");
                return default(TModel);
            }
        }

        public async Task<TModel> Update(TModel item)
        {
            try
            {
                return await _modelData.Update(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.WriteWithTime($"Failed to update the item: {ex.Message}");
                return default(TModel);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _modelData.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.WriteWithTime($"Failed to delete the item: {ex.Message}");
                return false;
            }
        }

    }    
}

