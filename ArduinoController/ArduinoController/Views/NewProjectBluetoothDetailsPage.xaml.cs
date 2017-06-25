using ArduinoController.ViewModels;
using System;
using Xamarin.Forms;

namespace ArduinoController.Views
{
    public partial class NewProjectBluetoothDetailsPage : ContentPage
    {
        NewProjectBluetoothDetailsViewModel viewModel;
        
        public NewProjectBluetoothDetailsPage(NewProjectBluetoothDetailsViewModel viewModel)
        {
            BindingContext = this.viewModel = viewModel;
            InitializeComponent();
        }
        
        async void SaveClicked(object sender, EventArgs e)
        {
            App.ProjectDatabase.SaveProject(viewModel.Project);
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
            viewModel.SaveBluetoothSettingCommand.Execute(null);
        }
    }
}