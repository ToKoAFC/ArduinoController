using SQLite;

namespace ArduinoController.Database.Models
{
    public class BluetoothSettings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public bool IsInt { get; set; }
        public string VarName { get; set; }
        public string Signal { get; set; }
    }
}
