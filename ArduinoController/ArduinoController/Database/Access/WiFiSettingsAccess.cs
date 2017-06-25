using ArduinoController.Database.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArduinoController.Database.Access
{
    public class WiFiSettingsAccess
    {
        readonly SQLiteConnection database;

        public WiFiSettingsAccess(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<WiFiSettings>();
        }

        public List<WiFiSettings> GetWiFiSettings(int projectId)
        {
            return database.Table<WiFiSettings>().Where(x => x.ProjectId == projectId).ToList();
        }

        public int SaveWiFiSettings(WiFiSettings settings)
        {
            if (settings.Id != 0)
            {
                return database.Update(settings);
            }
            return database.Insert(settings);
        }

        public int DeleteWiFiSettings(WiFiSettings setting)
        {
            return database.Delete(setting);
        }
    }
}
