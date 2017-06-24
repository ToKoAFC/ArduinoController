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
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }                
    }
}