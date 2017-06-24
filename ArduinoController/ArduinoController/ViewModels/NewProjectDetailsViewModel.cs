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
    public class NewProjectDetailsViewModel : BaseViewModel
    {
        public Command SaveWiFiSettingCommand { get; set; }
        public Project Project { get; set; }
        public string UrlValue { get; set; }
        public List<WiFiSettings> WiFiSettings { get; set; }
        public List<Output> Outputs { get; set; }

        public NewProjectDetailsViewModel(Project project)
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
            SaveWiFiSettingCommand = new Command(async () => await ExecuteSaveWiFiSettingCommand());

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
                        Url = UrlValue
                    });
                }
                foreach (var settings in WiFiSettings)
                {
                    await App.WiFiSettingsDatabase.SaveWiFiSettingstAsync(settings);
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