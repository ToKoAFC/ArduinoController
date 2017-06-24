using ArduinoController.Database.Models;
using ArduinoController.Helpers;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArduinoController.ViewModels
{
    public class ProjectDetailsViewModel : BaseViewModel
    {
        public Project Project { get; set; }
        public Command DeleteProjectCommand { get; set; }

        public ProjectDetailsViewModel(Project project = null)
        {
            Title = project.Name;
            Project = project;
            DeleteProjectCommand = new Command(async () => await ExecuteDeleteProjectCommand());
        }

        async Task ExecuteDeleteProjectCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await App.ProjectDatabase.DeleteProjectAsync(Project);                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to delete project.",
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