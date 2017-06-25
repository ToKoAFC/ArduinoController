using ArduinoController.Database.Models;
using ArduinoController.Helpers;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArduinoController.ViewModels
{
    public class NewProjectBluetoothDetailsViewModel : BaseViewModel
    {
        public Command SaveBluetoothSettingCommand { get; set; }

        Project project = new Project();
        public Project Project
        {
            get { return project; }
            set { SetProperty(ref project, value); }
        }

        public string UrlValue { get; set; }
        public ObservableRangeCollection<BluetoothSettings> BluetoothSettings { get; set; }
        public ObservableRangeCollection<Output> Outputs { get; set; }

        public NewProjectBluetoothDetailsViewModel(int projectId)
        {
            BluetoothSettings = new ObservableRangeCollection<BluetoothSettings>();
            LoadProject(projectId);
            SaveBluetoothSettingCommand = new Command(async () => await ExecuteSaveBluetoothSettingCommand());
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
            var bluetoothSettings = App.BluetoothSettingsDatabase.GetBluetoothSettings(projectId);
            if (bluetoothSettings == null || !bluetoothSettings.Any())
            {
                for (int i = 0; i < Project.OutputsCount; i++)
                {
                    Outputs.Add(new Output());
                }

                return;
            }

            var bluetoothSett = bluetoothSettings.Select(x => new Output
            {
                Name = x.VarName,
                Signal = x.Signal,
                Id = x.Id,
                IsInt = x.IsInt
            });
            Outputs.ReplaceRange(bluetoothSett);
        }

        async Task ExecuteSaveBluetoothSettingCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                foreach (var output in Outputs)
                {
                    BluetoothSettings.Add(new BluetoothSettings()
                    {
                        Signal = output.Signal,
                        ProjectId = Project.Id,
                        VarName = output.Name,
                        IsInt = output.IsInt,
                        Id = output.Id
                    });
                }
                foreach (var settings in BluetoothSettings)
                {
                    App.BluetoothSettingsDatabase.SaveBluetoothSettings(settings);
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