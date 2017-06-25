using ArduinoController.Database.Models;
using ArduinoController.ViewModels;
using System;
using Xamarin.Forms;

namespace ArduinoController.Views
{
    public partial class ManageProjectPage : ContentPage
    {
        public Project Project { get; set; }
        
        public ManageProjectPage(int projectId)
        {            
            var project = App.ProjectDatabase.GetProject(projectId);
            if (project == null)
            {
                Navigation.PopAsync();
            }
            Project = project;
            Title = project.Name;
            BindingContext = this;
            InitializeComponent();
        }

        void WiFiClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManageWiFiProjectPage(new ManageWiFiProjectViewModel(Project.Id)));
        }
        void BluetoothClicked(object sender, EventArgs e)
        {
            App.ProjectDatabase.SaveProject(Project);
            Navigation.PushAsync(new ManageBluetoothProjectPage(new ManageBluetoothProjectViewModel(Project.Id)));

        }
    }
}