#region Header
// Module               : Web Api Task controller
// Version              : 1.0
// Author               : Prathap (436812)
// Date                 : 09-Sep-2018
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

#region TaskController

namespace ProjectManager.WebAPI.Controllers
{
    public class TaskController : ApiController
    {
        ProjectManagerTaskBL TaskBL = new ProjectManagerTaskBL();

        /// <summary>
        /// Get all the Tasks 
        /// </summary>
        /// <returns>Tasks</returns>
        [HttpGet]
        public IHttpActionResult GetTasks()
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            List<TasksModel> Tasks = new List<TasksModel>();
            try
            {
                Tasks = TaskBL.GetTask();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(Tasks);
        }

        // GET api/<controller>/5
        /// <summary>
        /// Get Task baased on Task id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task</returns>
        [HttpGet]
        public IHttpActionResult GetTask(int id)
        {
            Task Task = new Task();
            try
            {
                Task = TaskBL.GetTaskById(id);
                if (Task != null)
                    return Ok(Task);
                else
                    return BadRequest("No Task found with Id as :" + id.ToString());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Get Parent task
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetParentTask()
        {
            List<ParentTask> parentTask = new List<ParentTask>();
            try
            {
                parentTask = TaskBL.GetParentTask();
                if (parentTask != null)
                    return Ok(parentTask);
                else
                    return BadRequest("No Parent Task found");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Add New Task
        /// </summary>
        /// <param name="Parent__ID"></param>
        /// <param name="Project_ID"></param>
        /// <param name="Task1"></param>
        /// <param name="Start_Date"></param>
        /// <param name="End_Date"></param>
        /// <param name="Priority"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult AddTask(int? Parent__ID, int? Project_ID, string Task1, DateTime? Start_Date, DateTime? End_Date, int? Priority, String Status)
        {
            Task Task = new Task();
            try
            {
                if (Status != "Parent")
                {
                    Task.Parent__ID = Parent__ID;
                }
                else if (Status == "Parent")
                {
                    Task.Parent__ID = null;
                }
                Task.End_Date = End_Date;

                Task.Priority = Priority;
                Task.Project_ID = Project_ID;
                Task.Start_Date = Start_Date;
                Task.Status = Status;
                Task.Task1 = Task1;
                TaskBL.AddTask(Task);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return StatusCode(HttpStatusCode.Created);
        }

        /// <summary>
        /// Update existing Task information
        /// </summary>
        /// <param name="Task"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult UpdatTask(Task Task)
        {
            try
            {
                TaskBL.UpdateTask(Task);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return StatusCode(HttpStatusCode.OK);
        }

        /// <summary>
        /// Delete existing Task
        /// </summary>
        /// <param name="Task"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult DeleteTask(Task Task)
        {
            try
            {
                TaskBL.DeleteTask(Task);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return StatusCode(HttpStatusCode.OK);
        }
        /// <summary>
        /// Get All the task related to particular project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetTasks_ByProjId(int id)
        {
            List<TasksModel> Task = new List<TasksModel>();
            try
            {
                Task = TaskBL.GetTaskByProjectId(id);
                if (Task != null)
                    return Ok(Task);
                else
                    return BadRequest("No Task found with Project Id as :" + id.ToString());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Get All the completed Tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetCompletedTask()
        {
            List<TasksModel> Task = new List<TasksModel>();
            try
            {
                Task = TaskBL.GetCompletedTask();
                if (Task != null)
                    return Ok(Task);
                else
                    return BadRequest("There is no Completed task");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
#endregion