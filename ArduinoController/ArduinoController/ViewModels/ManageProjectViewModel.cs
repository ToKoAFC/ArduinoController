using ArduinoController.Database.Models;
using ArduinoController.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

        public ManageProjectViewModel(int projectId)
        {
            LoadProject(projectId);          
        }

        void LoadProject(int projectId)
        {
            var project =  App.ProjectDatabase.GetProject(projectId);
            if (project == null)
            {
                Project = new Project();
            }
            Project = project;
            Title = project.Name;
            Outputs = new List<Output>();
            var wifiSettings = App.WiFiSettingsDatabase.GetWiFiSettings(projectId);
            if (wifiSettings == null || !wifiSettings.Any())
            {
                for (int i = 0; i < Project.OutputsCount; i++)
                {
                    Outputs.Add(new Output());
                }
                return;
            }
            UrlValue = wifiSettings.FirstOrDefault().Url;
            Outputs = wifiSettings.Select(x => new Output
            {
                Name = x.VarName,
                Signal = x.Controller
            }).ToList();
        }

        public void SendRequest(string url, string action)
        {
            var fullURL = $"{url}/{action}";
            var request = HttpWebRequest.CreateHttp(fullURL);
            var response = request.GetResponseAsync();
        }
        
    }
}