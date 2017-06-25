using ArduinoController.ViewModels;
using System;
using Xamarin.Forms;

namespace ArduinoController.Views
{
    public partial class ManageWiFiProjectPage : ContentPage
    {
        ManageWiFiProjectViewModel viewModel;

        public ManageWiFiProjectPage(ManageWiFiProjectViewModel viewModel)
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
            viewModel.SendRequest(viewModel.UrlValue, output.Signal);
        }
    }
}