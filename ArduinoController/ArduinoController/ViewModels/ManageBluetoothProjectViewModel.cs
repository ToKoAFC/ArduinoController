using ArduinoController.Database.Models;
using ArduinoController.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ArduinoController
{
    public class ManageBluetoothProjectViewModel : BaseViewModel,INotifyPropertyChanged
    {

        public Project Project { get; set; }
        public List<BluetoothSettings> BluetoothSettings { get; set; }
        public List<Output> Outputs { get; set; }
        public ObservableCollection<string> ListOfDevices { get; set; } = new ObservableCollection<string>();
        public string SelectedBthDevice { get; set; } = "";
        bool _isConnected { get; set; } = false;
        int _sleepTime { get; set; } = 250;

        public String SleepTime
        {
            get { return _sleepTime.ToString(); }
            set
            {
                try
                {
                    _sleepTime = int.Parse(value);
                }
                catch { }
            }
        }

        private bool _isSelectedBthDevice
        {
            get
            {
                if (string.IsNullOrEmpty(SelectedBthDevice)) return false; return true;
            }
        }

        public bool IsConnectEnabled
        {
            get
            {
                if (_isSelectedBthDevice == false)
                    return false;
                return !_isConnected;
            }
        }

        public bool IsDisconnectEnabled
        {
            get
            {
                if (_isSelectedBthDevice == false)
                    return false;
                return _isConnected;
            }
        }

        public bool IsPickerEnabled
        {
            get
            {
                return !_isConnected;
            }
        }

        public ManageBluetoothProjectViewModel(int projectId)
        {
            LoadProject(projectId);

            MessagingCenter.Subscribe<App>(this, "Sleep", (obj) =>
            {
                // When the app "sleep", I close the connection with bluetooth
                if (_isConnected)
                    DependencyService.Get<IBth>().Cancel();

            });

            MessagingCenter.Subscribe<App>(this, "Resume", (obj) =>
            {

                // When the app "resume" I try to restart the connection with bluetooth
                if (_isConnected)
                    DependencyService.Get<IBth>().Start(SelectedBthDevice, _sleepTime, true);

            });


            this.ConnectCommand = new Command(() => {

                // Try to connect to a bth device
                DependencyService.Get<IBth>().Start(SelectedBthDevice, _sleepTime, true);
                _isConnected = true;                
            });

            this.DisconnectCommand = new Command(() => {

                // Disconnect from bth device
                DependencyService.Get<IBth>().Cancel();
                _isConnected = false;
            });


            try
            {
                // At startup, I load all paired devices
                ListOfDevices = DependencyService.Get<IBth>().PairedDevices();
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
            }
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
            Outputs = new List<Output>();
            var bluetoothSettings = App.BluetoothSettingsDatabase.GetBluetoothSettings(projectId);
            if (bluetoothSettings == null || !bluetoothSettings.Any())
            {
                for (int i = 0; i < Project.OutputsCount; i++)
                {
                    Outputs.Add(new Output());
                }
                return;
            }

            Outputs = bluetoothSettings.Select(x => new Output
            {
                Name = x.VarName,
                Signal = x.Signal,
                IsInt = x.IsInt,
                Id = x.Id
            }).ToList();
        }

        public ICommand ConnectCommand { get; protected set; }
        public ICommand DisconnectCommand { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
