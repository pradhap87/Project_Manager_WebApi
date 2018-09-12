using ProjectManager.DataLayer;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ProjectManager.BusinessLayer
{
    public class ProjectManagerProjectBL
    {
        //DAL Context
        ProjectManagerContext db = new ProjectManagerContext();
        /// <summary>
        /// Add New project
        /// </summary>
        /// <param name="Project"></param>
        public void AddProject(Project Project)
        {
            db.Projects.Add(Project);
            db.SaveChanges();
        }
        /// <summary>
        /// Get Project by Projectid
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        public Project GetProjectById(int ProjectId)
        {
            Project u = new Project();
            u = db.Projects.Find(ProjectId);
            return u;
        }
        /// <summary>
        /// Get all the Projects
        /// </summary>
        /// <returns></returns>
        public List<Project> GetProject()
        {
            List<Project> Projects = new List<Project>();
            Projects = db.Projects.ToList();
            return Projects;
        }
        /// <summary>
        /// Delete Project
        /// </summary>
        /// <param name="Project"></param>
        public void DeleteProject(Project Project)
        {
            db.Projects.Attach(Project);
            db.Projects.Remove(Project);
            db.SaveChanges();
        }
        /// <summary>
        /// Updated Project
        /// </summary>
        /// <param name="Project"></param>
        public void UpdateProject(Project Project)
        {
            db.Projects.AddOrUpdate(Project);
            db.SaveChanges();
        }

    }
}
