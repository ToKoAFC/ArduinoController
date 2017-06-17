using ArduinoController.Database.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArduinoController.Database.Access
{
    public class ProjectAccess
    {
        readonly SQLiteAsyncConnection database;

        public ProjectAccess(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Project>().Wait();
        }

        public Task<List<Project>> GetProjectsAsync()
        {
            return database.Table<Project>().ToListAsync();
        }

        public Task<Project> GetProjectAsync(int projectId)
        {
            return database.Table<Project>().Where(x => x.Id == projectId).FirstOrDefaultAsync();
        }

        public Task<int> SaveProjectAsync(Project project)
        {
            if(project.Id != 0)
            {
                return database.UpdateAsync(project);
            }
            return database.InsertAsync(project);
        }

        public Task<int> DeleteProjectAsync(Project project)
        {
            return database.DeleteAsync(project);
        }
    }
}
