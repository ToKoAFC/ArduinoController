
using ArduinoController.Arduino;
using ArduinoController.Database;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(LocalFileHelper))]
namespace ArduinoController.Arduino
{
    public class LocalFileHelper : ILocalFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string libFolder = Path.Combine(docFolder, "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);
        }
    }
}