using System;

using ArduinoController.Models;

using Xamarin.Forms;
using ArduinoController.Database.Models;
using ArduinoController.ViewModels;

namespace ArduinoController.Views
{
    public partial class NewProjectConnTypePage : ContentPage
    {
        NewProjectDetailsViewModel viewModel;


        public NewProjectConnTypePage(NewProjectDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        async void WiFiClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewProjectWiFiDetailsPage(new NewProjectDetailsViewModel(viewModel.Project)));
        }
        async void BluetoothClicked(object sender, EventArgs e)
        {
            await App.Database.SaveProjectAsync(viewModel.Project);
        }
        
    }
}