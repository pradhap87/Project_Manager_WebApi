using ProjectManager.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ProjectManager.BusinessLayer
{
    public class ProjectManagerTaskBL
    {
        //DAL Context
        ProjectManagerContext db = new ProjectManagerContext();
        /// <summary>
        /// Add New Task
        /// </summary>
        /// <param name="Task"></param>
        public void AddTask(Task Task)
        {
            ParentTask pTask = new ParentTask();

            if(Task.Status == "Parent")
            {
                pTask.Parent_Task = Task.Task1;
                db.ParentTasks.Add(pTask);
                db.SaveChanges();
            }          

            var pt = db.ParentTasks.ToList();

            
            foreach (ParentTask t in pt)
            {
                if(t.Parent_Task== Task.Task1)
                {
                    Task.Parent__ID = t.Parent_ID;
                }
            }
            
            db.Tasks.Add(Task);
            db.SaveChanges();
        }
        /// <summary>
        /// Get Task by Taskid
        /// </summary>
        /// <param name="TaskId"></param>
        /// <returns></returns>
        public Task GetTaskById(int TaskId)
        {
            Task u = new Task();
            u = db.Tasks.Find(TaskId);
            return u;
        }
        /// <summary>
        /// Get Task by project 
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        public List<TasksModel> GetTaskByProjectId(int ProjectId)
        {
            List<TasksModel> lstTasks = new List<TasksModel>();
             lstTasks = (from t in db.Tasks
                        join pt in db.ParentTasks on t.Parent__ID equals pt.Parent_ID into tpt
                        from parent in tpt.DefaultIfEmpty()
                         where t.Project_ID == ProjectId
                         select new TasksModel { Task_ID = t.Task_ID, Task1 = t.Task1, Project_ID = t.Project_ID, Parent_Task = parent.Parent_Task, Status = t.Status, End_Date = t.End_Date, Priority = t.Priority, Start_Date = t.Start_Date }).ToList();

            return lstTasks;
        }
        /// <summary>
        /// Get all the Tasks
        /// </summary>
        /// <returns></returns>
        public List<TasksModel> GetTask()
        {
            List<TasksModel> lstTasks = new List<TasksModel>();
            lstTasks = (from t in db.Tasks
                        join pt in db.ParentTasks on t.Parent__ID equals pt.Parent_ID into tpt
                        from parent in tpt.DefaultIfEmpty()
                        select new TasksModel { Task_ID = t.Task_ID, Task1 = t.Task1, Project_ID = t.Project_ID, Parent_Task = parent.Parent_Task, Status = t.Status, End_Date = t.End_Date, Priority = t.Priority, Start_Date = t.Start_Date }).ToList();

            return lstTasks;
        }
        /// <summary>
        /// Get all the completed Tasks
        /// </summary>
        /// <returns></returns>
        public List<TasksModel> GetCompletedTask()
        {
            List<TasksModel> lstTasks = new List<TasksModel>();
            lstTasks = (from t in db.Tasks
                        join pt in db.ParentTasks on t.Parent__ID equals pt.Parent_ID into tpt
                        from parent in tpt.DefaultIfEmpty()
                        where t.Status == "Complete"
                        select new TasksModel { Task_ID = t.Task_ID, Task1 = t.Task1, Project_ID = t.Project_ID, Parent_Task = parent.Parent_Task, Status = t.Status, End_Date = t.End_Date, Priority = t.Priority, Start_Date = t.Start_Date }).ToList();

            return lstTasks;
        }

        /// <summary>
        /// Delete Task
        /// </summary>
        /// <param name="Task"></param>
        public void DeleteTask(Task Task)
        {
            db.Tasks.Attach(Task);
            db.Tasks.Remove(Task);
            db.SaveChanges();
        }
        /// <summary>
        /// Updated Task
        /// </summary>
        /// <param name="Task"></param>
        public void UpdateTask(Task Task)
        {
            db.Tasks.AddOrUpdate(Task);
            db.SaveChanges();
        }
        /// <summary>
        /// Get Parent task
        /// </summary>
        /// <returns></returns>
        public List<ParentTask> GetParentTask()
        {
            List<ParentTask> Parent = new List<ParentTask>();
            Parent = db.ParentTasks.ToList();
            return Parent;
        }

    }
}
