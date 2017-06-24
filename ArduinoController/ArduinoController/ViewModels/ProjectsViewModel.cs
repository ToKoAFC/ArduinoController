using ArduinoController.Database.Models;
using ArduinoController.Helpers;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArduinoController.ViewModels
{
    public class ProjectsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Project> Projects { get; set; }
        public Command LoadProjectsCommand { get; set; }

        public ProjectsViewModel()
        {
            Title = "Projects";
            Projects = new ObservableRangeCollection<Project>();
            LoadProjectsCommand = new Command(async () => await ExecuteLoadProjectsCommand());
            
        }

        async Task ExecuteLoadProjectsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Projects.Clear();
                var projects = await App.ProjectDatabase.GetProjectsAsync();
                Projects.ReplaceRange(projects);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load projects.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}