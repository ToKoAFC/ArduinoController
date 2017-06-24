using ArduinoController.Database.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArduinoController.Database.Access
{
    public class WiFiSettingsAccess
    {
        readonly SQLiteAsyncConnection database;

        public WiFiSettingsAccess(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<WiFiSettings>().Wait();
        }

        public Task<List<WiFiSettings>> GetWiFiSettingsAsync(int projectId)
        {
            return database.Table<WiFiSettings>().Where(x => x.ProjectId == projectId).ToListAsync();
        }

        public Task<int> SaveWiFiSettingstAsync(WiFiSettings settings)
        {
            if (settings.Id != 0)
            {
                return database.UpdateAsync(settings);
            }
            return database.InsertAsync(settings);
        }

        public Task<int> DeleteWiFiSettingsAsync(WiFiSettings setting)
        {
            return database.DeleteAsync(setting);
        }
    }
}
