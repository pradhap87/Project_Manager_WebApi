#region Header
// Module               : Web Api Project controller
// Version              : 1.0
// Author               : Prathap (436812)
// Date                 : 08-Sep-2018
// Purpose              : FSD Finall submission - Project Manager
#endregion

#region Namespace
using ProjectManager.DataLayer;
using ProjectManager.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
#endregion

#region ProjectController
namespace ProjectManager.WebAPI.Controllers
{    
    public class ProjectController : ApiController
    {
        ProjectManagerProjectBL projectBL = new ProjectManagerProjectBL();
        /// <summary>
        /// Get Projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetProjects()
         {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            List<Project> projects = new List<Project>();
            try
            {
                projects = projectBL.GetProject();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(projects);
        }


        // GET api/<controller>/5
        /// <summary>
        /// Get Project baased on Project id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Project</returns>
        [HttpGet]
        public IHttpActionResult GetProject(int id)
        {
            Project Project = new Project();
            try
            {
                Project = projectBL.GetProjectById(id);
                if (Project != null)
                    return Ok(Project);
                else
                    return BadRequest("No Project found with Id as :" + id.ToString());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Add New Project
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult AddProject(String project, int? managerId, Int16 priority, DateTime startDate, DateTime endDate)
        {
            Project Project = new Project();
            try
            {
                Project.Project1 = project;
                Project.End_Date = endDate;
                Project.Manager_Id = managerId;
                Project.Priority = priority;
                Project.Start_Date = startDate;                
                projectBL.AddProject(Project);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return StatusCode(HttpStatusCode.Created);
        }

        /// <summary>
        /// Update existing Project information
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult UpdatProject(Project Project)
        {
            try
            {
                projectBL.UpdateProject(Project);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return StatusCode(HttpStatusCode.OK);
        }

        /// <summary>
        /// Delete existing Project
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult DeleteProject(Project Project)
        {
            try
            {
                projectBL.DeleteProject(Project);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return StatusCode(HttpStatusCode.OK);
        }

    }
}
#endregion