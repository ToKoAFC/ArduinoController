using ArduinoController.ViewModels;
using System;
using Xamarin.Forms;

namespace ArduinoController.Views
{
    public partial class ManageBluetoothProjectPage : ContentPage
    {
        ManageBluetoothProjectViewModel viewModel;

        public ManageBluetoothProjectPage(ManageBluetoothProjectViewModel viewModel)
        {
            BindingContext = this.viewModel = viewModel;
            InitializeComponent();
        }
        private void OutputClicked(object sender, EventArgs e)
        {
            var binObj = (BindableObject)sender;
            var output = (Output)binObj.BindingContext;
            if (output == null)
            {
                return;
            }
        }
    }
}