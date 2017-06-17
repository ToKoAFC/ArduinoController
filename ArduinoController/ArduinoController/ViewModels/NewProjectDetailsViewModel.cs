using ArduinoController.Database.Models;
using System;
using System.Collections.Generic;

namespace ArduinoController.ViewModels
{
    public class NewProjectDetailsViewModel : BaseViewModel
    {
        public NewProjectDetailsViewModel(Project project)
        {
            Title = project.Name;
            Project = project;
            Outputs = new List<Output>();
            for (int i = 0; i < project.OutputsCount; i++)
            {
                Outputs.Add(new Output());
            }
        }

        public Project Project { get; set; }
        public List<Output> Outputs { get; set; }

    }
}