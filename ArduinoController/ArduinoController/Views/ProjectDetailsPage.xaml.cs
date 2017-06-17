
using ArduinoController.ViewModels;

using Xamarin.Forms;

namespace ArduinoController.Views
{
    public partial class ProjectDetailsPage : ContentPage
    {
        ProjectDetailsViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ProjectDetailsPage()
        {
            InitializeComponent();
        }

        public ProjectDetailsPage(ProjectDetailsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
