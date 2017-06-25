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
    public class NewProjectWifiDetailsViewModel : BaseViewModel
    {
        public Command SaveWiFiSettingCommand { get; set; }

        Project project = new Project();
        public Project Project
        {
            get {return project;}
            set { SetProperty(ref project, value);}
        }
     
        public string UrlValue { get; set; }
        public ObservableRangeCollection<WiFiSettings> WiFiSettings { get; set; }
        public ObservableRangeCollection<Output> Outputs { get; set; }

        public NewProjectWifiDetailsViewModel(int projectId)
        {
            WiFiSettings = new ObservableRangeCollection<WiFiSettings>();
            LoadProject(projectId);
            SaveWiFiSettingCommand = new Command(async () => await ExecuteSaveWiFiSettingCommand());
        }

        void LoadProject(int projectId)
        {
            var project = App.ProjectDatabase.GetProject(projectId);
            if (project == null)
            {
                Project = new Project();
            }
            Project = project;
            Title = project.Name;

            Outputs = new ObservableRangeCollection<Output>();
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
            var wifiSett = wifiSettings.Select(x => new Output
            {
                Name = x.VarName,
                Signal = x.Controller,
                Id = x.Id
            });
            Outputs.ReplaceRange(wifiSett);
        }
        
        async Task ExecuteSaveWiFiSettingCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                foreach (var output in Outputs)
                {
                    WiFiSettings.Add(new WiFiSettings()
                    {
                        Controller = output.Signal,
                        ProjectId = Project.Id,
                        VarName = output.Name,
                        Url = UrlValue,
                        Id = output.Id
                    });
                }
                foreach (var settings in WiFiSettings)
                {
                    App.WiFiSettingsDatabase.SaveWiFiSettings(settings);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to save settings.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}