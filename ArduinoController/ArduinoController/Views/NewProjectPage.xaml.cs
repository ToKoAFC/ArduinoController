using ArduinoController.Database.Models;
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
                Name = "Item name",
                Description = "This is a nice description"
            };

            BindingContext = this;
        }

        async void SaveClicked(object sender, EventArgs e)
        {
            await App.Database.SaveProjectAsync(Project);
            await Navigation.PushAsync(new NewProjectWiFiDetailsPage(new ViewModels.NewProjectDetailsViewModel(Project)));
        }
    }
}