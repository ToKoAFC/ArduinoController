using System;

using ArduinoController.Models;

using Xamarin.Forms;
using ArduinoController.Database.Models;
using ArduinoController.ViewModels;

namespace ArduinoController.Views
{
    public partial class NewProjectWiFiDetailsPage : ContentPage
    {
        NewProjectDetailsViewModel viewModel;
        
        public NewProjectWiFiDetailsPage(NewProjectDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }
        
        async void SaveClicked(object sender, EventArgs e)
        {
            await App.ProjectDatabase.SaveProjectAsync(viewModel.Project);

        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var output = e.SelectedItem as Output;
            if (output == null)
                return;
            
            OutputsListView.SelectedItem = null;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            viewModel.SaveWiFiSettingCommand.Execute(null);
        }
    }
}