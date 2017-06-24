using SQLite;

namespace ArduinoController.Database.Models
{
    public class WiFiSettings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Url { get; set; }
        public string VarName { get; set; }
        public string Controller { get; set; }
    }
}
