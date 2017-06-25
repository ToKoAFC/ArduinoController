using ArduinoController.Database.Models;
using ArduinoController.ViewModels;
using System;
using Xamarin.Forms;

namespace ArduinoController.Views
{
    public partial class NewProjectPage : ContentPage
    {
        public Project Project { get; set; }

        public NewProjectPage()
        {
            InitializeComponent();

            Project = new Project
            {
                Name = "Project name",
                Description = "Write some words about your project"
            };

            BindingContext = this;
        }

        void WiFiClicked(object sender, EventArgs e)
        {
            App.ProjectDatabase.SaveProject(Project);
            Navigation.PushAsync(new NewProjectWiFiDetailsPage(new NewProjectDetailsViewModel(Project.Id)));
        }
        void BluetoothClicked(object sender, EventArgs e)
        {
            App.ProjectDatabase.SaveProject(Project);
        }
    }
}