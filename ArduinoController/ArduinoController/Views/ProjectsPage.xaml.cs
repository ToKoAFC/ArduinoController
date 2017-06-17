using System;

using ArduinoController.Models;
using ArduinoController.ViewModels;

using Xamarin.Forms;
using ArduinoController.Database.Models;

namespace ArduinoController.Views
{
    public partial class ProjectsPage : ContentPage
    {
        ProjectsViewModel viewModel;

        public ProjectsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ProjectsViewModel();
        }

        async void OnProjectSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var project = args.SelectedItem as Project;
            if (project == null)
                return;

            await Navigation.PushAsync(new ProjectDetailsPage(new ProjectDetailsViewModel(project)));
            
            ProjectsListView.SelectedItem = null;
        }

        async void AddProjectClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewProjectPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
                viewModel.LoadProjectsCommand.Execute(null);
        }
    }
}
