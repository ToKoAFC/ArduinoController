namespace ArduinoController.ViewModels
{
    public class Output
    {
        public Output()
        {
            IsInt = false;
            Name = string.Empty;
            Signal = string.Empty;
        }
        public int Id {get; set; }
        public string Name { get; set; }
        public string Signal { get; set; }
        public bool IsInt { get; set; }
    }
}

