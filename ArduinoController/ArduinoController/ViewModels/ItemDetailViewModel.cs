using ArduinoController.Database.Models;

namespace ArduinoController.ViewModels
{
    public class ProjectDetailsViewModel : BaseViewModel
    {
        public Project Project { get; set; }
        public ProjectDetailsViewModel(Project project = null)
        {
            Title = project.Name;
            Project = project;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}