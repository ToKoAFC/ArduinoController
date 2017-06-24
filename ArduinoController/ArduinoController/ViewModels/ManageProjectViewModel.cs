using ArduinoController.Database.Models;
using ArduinoController.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArduinoController.ViewModels
{
    public class ManageProjectViewModel : BaseViewModel
    {
        public Project Project { get; set; }
        public string UrlValue { get; set; }
        public List<WiFiSettings> WiFiSettings { get; set; }
        public List<Output> Outputs { get; set; }

        public ManageProjectViewModel(Project project)
        {
            WiFiSettings = new List<WiFiSettings>();
            Title = project.Name;
            Project = project;
            Outputs = new List<Output>();
            for (int i = 0; i < project.OutputsCount; i++)
            {
                Outputs.Add(new Output());
            }
            LoadSettings();
        }

        async Task LoadSettings()
        {
            var wifiSettings = await App.WiFiSettingsDatabase.GetWiFiSettingsAsync(Project.Id);
            if (wifiSettings == null)
            {
                return;
            }
            UrlValue = wifiSettings.FirstOrDefault().Url;
            Outputs = wifiSettings.Select(x => new Output
            {
                Name = x.VarName,
                Signal = x.Controller
            }).ToList();
        }
    }
}