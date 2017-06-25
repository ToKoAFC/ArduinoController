using System;

using ArduinoController.Models;

using Xamarin.Forms;
using ArduinoController.Database.Models;
using ArduinoController.ViewModels;

namespace ArduinoController.Views
{
    public partial class ManageProjectPage : ContentPage
    {
        ManageProjectViewModel viewModel;

        public ManageProjectPage(ManageProjectViewModel viewModel)
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