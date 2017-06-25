using ArduinoController.Database.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace ArduinoController.Database.Access
{
    public class ProjectAccess
    {
        readonly SQLiteConnection database;

        public ProjectAccess(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<Project>();
        }

        public List<Project> GetProjects()
        {
            return database.Table<Project>().ToList();
        }

        public Project GetProject(int projectId)
        {
            return database.Table<Project>().Where(x => x.Id == projectId).FirstOrDefault();
        }

        public int SaveProject(Project project)
        {
            if (project.Id != 0)
            {
                return database.Update(project);
            }
            return database.Insert(project);
        }

        public int DeleteProject(Project project)
        {
            return database.Delete(project);
        }
    }
}
