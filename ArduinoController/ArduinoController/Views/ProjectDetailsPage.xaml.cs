
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

        private void DeleteClicked(object sender, System.EventArgs e)
        {
            viewModel.DeleteProjectCommand.Execute(null);
            Navigation.PopToRootAsync();
        }

        private void EditClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewProjectWiFiDetailsPage(new NewProjectDetailsViewModel(viewModel.Project)));
        }
        private void ManageClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ManageProjectPage(new ManageProjectViewModel(viewModel.Project)));
        }
    }
}
