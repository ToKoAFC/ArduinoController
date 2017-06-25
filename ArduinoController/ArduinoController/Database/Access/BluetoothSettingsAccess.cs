using ArduinoController.Database.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace ArduinoController.Database.Access
{
    public class BluetoothSettingsAccess
    {
        readonly SQLiteConnection database;

        public BluetoothSettingsAccess(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<BluetoothSettings>();
        }

        public List<BluetoothSettings> GetBluetoothSettings(int projectId)
        {
            return database.Table<BluetoothSettings>().Where(x => x.ProjectId == projectId).ToList();
        }

        public int SaveBluetoothSettings(BluetoothSettings settings)
        {
            if (settings.Id != 0)
            {
                return database.Update(settings);
            }
            return database.Insert(settings);
        }

        public int DeleteBluetoothSettings(BluetoothSettings setting)
        {
            return database.Delete(setting);
        }
    }
}
