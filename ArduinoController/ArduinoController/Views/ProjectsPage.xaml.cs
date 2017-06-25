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
            BindingContext = viewModel = new ProjectsViewModel();
            InitializeComponent();
        }
        
        private void DeleteClicked(object sender, System.EventArgs e)
        {
            var binObj = (BindableObject)sender;
            var project = (Project)binObj.BindingContext;
            if (project == null)
                return;
            App.ProjectDatabase.DeleteProject(project);
            viewModel.Projects.Remove(project);
        }

        private void EditClicked(object sender, System.EventArgs e)
        {
            var binObj = (BindableObject)sender;
            var project = (Project)binObj.BindingContext;
            if (project == null)
                return;

            Navigation.PushAsync(new NewProjectWiFiDetailsPage(new NewProjectDetailsViewModel(project.Id)));
        }
        private void ManageClicked(object sender, System.EventArgs e)
        {
            var binObj = (BindableObject)sender;
            var project = (Project)binObj.BindingContext;
            if (project == null)
                return;

            Navigation.PushAsync(new ManageProjectPage(new ManageProjectViewModel(project.Id)));
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

        private void ProjectsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ProjectsListView.SelectedItem = null;
        }
    }
}
