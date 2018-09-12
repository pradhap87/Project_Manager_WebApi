#region Header
// Module               : Web Api Project controller
// Version              : 1.0
// Author               : Prathap (436812)
// Date                 : 08-Sep-2018
// Purpose              : FSD Finall submission - Project Manager
#endregion
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManager.WebAPI.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net.Http;
using ProjectManager.DataLayer;
using System.Net;

namespace ProjectManager.WebAPI.Tests
{
    [TestClass]
    public class ProjectManagerUnitTest
    {
        /// <summary>
        /// Test Method For selecting all the Tasks
        /// </summary>
        [TestMethod]
        public void TestGetTasks()
        {
            var apiController = new TaskController();
            var result = apiController.GetTasks();
            Assert.IsNotNull(result);
        }
        /// <summary>
        /// Test Method For selecting the Tasks with TaskID.
        /// </summary>
        [TestMethod]
        public void TestGetTask()
        {
            var apiController = new TaskController()
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            IHttpActionResult actionResult = apiController.GetTask(2320);
            var contentResult = actionResult as OkNegotiatedContentResult<Task>;
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(2320, contentResult.Content.Task_ID);
        }
        /// <summary>
        /// Test Method for adding one new Task
        /// </summary>
        [TestMethod]
        public void TestAddTask()
        {
            var apiController = new TaskController();
            IHttpActionResult actionResult = apiController.AddTask(3116, 100, "Unit Test Task", Convert.ToDateTime("2018-08-08"), Convert.ToDateTime("2018-10-10"), 30, "Testing");
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(HttpStatusCode.Created, ((System.Web.Http.Results.StatusCodeResult)actionResult).StatusCode);
        }
        /// <summary>
        /// TestMethod for updating the task
        /// </summary>
        [TestMethod]
        public void TestUpdateTask()
        {
            var apiController = new TaskController();

            DataLayer.Task t = new Task();
            t.Task_ID = 2320;
            t.Parent__ID = null;
            t.Priority = 22;
            t.Start_Date = Convert.ToDateTime("2018-08-08");
            t.End_Date = Convert.ToDateTime("2018-11-11");
            t.Status = "Updated";

            IHttpActionResult actionResult = apiController.UpdatTask(t);
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(HttpStatusCode.OK, ((System.Web.Http.Results.StatusCodeResult)actionResult).StatusCode);
        }
        /// <summary>
        /// Test Method for Delete Task
        /// </summary>
        [TestMethod]
        public void TestDeleteTask()
        {
            var apiController = new TaskController();
            DataLayer.Task t = new Task();
            t.Task_ID = 2320;
            t.Task1 = "FSD Capsule";
            t.Parent__ID = null;
            t.Priority = 10;
            t.Start_Date = Convert.ToDateTime("2018-08-08");
            t.End_Date = Convert.ToDateTime("2018-10-10");

            IHttpActionResult actionResult = apiController.DeleteTask(t);
            Assert.IsNotNull(actionResult);
            if (((System.Web.Http.Results.StatusCodeResult)actionResult).StatusCode == HttpStatusCode.OK)
                Assert.AreEqual(HttpStatusCode.OK, ((System.Web.Http.Results.StatusCodeResult)actionResult).StatusCode);
        }
        /// <summary>
        /// Test Method For selecting the Tasks by ProjectID.
        /// </summary>
        [TestMethod]
        public void TestGetTaskByProject_Id()
        {
            var apiController = new TaskController()
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            IHttpActionResult actionResult = apiController.GetTasks_ByProjId(1106);
            Assert.IsNotNull(actionResult);
        }
        /// <summary>
        /// Test Method For selecting the Tasks by status (Completed Task).
        /// </summary>
        [TestMethod]
        public void TestGetCompleted()
        {
            var apiController = new TaskController()
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            IHttpActionResult actionResult = apiController.GetCompletedTask();
            Assert.IsNotNull(actionResult);
        }
        /// <summary>
        /// Test Method For selecting all the Projects
        /// </summary>
        [TestMethod]
        public void TestGetProjects()
        {
            var apiController = new ProjectController();
            var result = apiController.GetProjects();
            Assert.IsNotNull(result);
        }
        /// <summary>
        /// Test Method For selecting the Project based on Project Id
        /// </summary>
        [TestMethod]
        public void TestGetProjectById()
        {
            var apiController = new ProjectController()
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            IHttpActionResult actionResult = apiController.GetProject(1106);
            var contentResult = actionResult as OkNegotiatedContentResult<Project>;
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1106, contentResult.Content.Project_ID);
        }
        /// <summary>
        /// Test Method for adding one new Project
        /// </summary>
        [TestMethod]
        public void TestAddProject()
        {
            var apiController = new ProjectController();
            IHttpActionResult actionResult = apiController.AddProject("Unit Test Project", 1102, 20, Convert.ToDateTime("2018-08-08"), Convert.ToDateTime("2018-10-10"));
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(HttpStatusCode.Created, ((System.Web.Http.Results.StatusCodeResult)actionResult).StatusCode);
        }
        /// <summary>
        /// TestMethod for updating the project
        /// </summary>
        [TestMethod]
        public void TestUpdateProject()
        {
            var apiController = new ProjectController();

            DataLayer.Project p = new Project();
            p.Project_ID = 1106;
            p.Project1 = "Unit testing";
            p.Manager_Id = 1102;
            p.Priority = 22;
            p.Start_Date = Convert.ToDateTime("2018-08-08");
            p.End_Date = Convert.ToDateTime("2018-11-11");

            IHttpActionResult actionResult = apiController.UpdatProject(p);
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(HttpStatusCode.OK, ((System.Web.Http.Results.StatusCodeResult)actionResult).StatusCode);
        }
        /// <summary>
        /// Test Method for Delete Project
        /// </summary>
        [TestMethod]
        public void TestDeleteProject()
        {
            var apiController = new ProjectController();

            DataLayer.Project p = new Project();
            p.Project_ID = 1106;
            p.Project1 = "OASIS Unit Testing";
            p.Manager_Id = 1102;
            p.Priority = 22;
            p.Start_Date = Convert.ToDateTime("2018-08-08");
            p.End_Date = Convert.ToDateTime("2018-11-11");

            IHttpActionResult actionResult = apiController.DeleteProject(p);
            Assert.IsNotNull(actionResult);
            if (((System.Web.Http.Results.StatusCodeResult)actionResult).StatusCode == HttpStatusCode.OK)
                Assert.AreEqual(HttpStatusCode.OK, ((System.Web.Http.Results.StatusCodeResult)actionResult).StatusCode);
        }
        /// <summary>
        /// Test Method For selecting all the Users
        /// </summary>
        [TestMethod]
        public void TestGetUsers()
        {
            var apiController = new UsersController();
            var result = apiController.GetUsers();
            Assert.IsNotNull(result);
        }
        /// <summary>
        /// Test Method for Getting User by User ID
        /// </summary>
        [TestMethod]
        public void TestGetUserById()
        {
            var apiController = new UsersController()
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            IHttpActionResult actionResult = apiController.GetUser(105);
            var contentResult = actionResult as OkNegotiatedContentResult<User>;
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(105, contentResult.Content.User_ID);
        }
        /// <summary>
        /// Test Method for adding one new User
        /// </summary>
        [TestMethod]
        public void TestAddUser()
        {
            var apiController = new UsersController();
            IHttpActionResult actionResult = apiController.AddUser("Unit", "Test", 436845);
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(HttpStatusCode.Created, ((System.Web.Http.Results.StatusCodeResult)actionResult).StatusCode);
        }
        /// <summary>
        /// TestMethod for updating the User
        /// </summary>
        [TestMethod]
        public void TestUpdateUser()
        {
            var apiController = new UsersController();

            DataLayer.User u = new User();
            u.First_Name = "Test";
            u.User_ID = 105;
            u.Last_Name = "Unit";
            u.Employee_ID = 7894;

            IHttpActionResult actionResult = apiController.UpdatUser(u);
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(HttpStatusCode.OK, ((System.Web.Http.Results.StatusCodeResult)actionResult).StatusCode);
        }
        /// <summary>
        /// Test Method for Delete User
        /// </summary>
        [TestMethod]
        public void TestDeleteUser()
        {
            var apiController = new UsersController();

            DataLayer.User u = new User();
            u.First_Name = "Test";
            u.User_ID = 105;
            u.Last_Name = "Unit";
            u.Employee_ID = 7894;

            IHttpActionResult actionResult = apiController.DeleteUser(u);
            Assert.IsNotNull(actionResult);
            if (((System.Web.Http.Results.StatusCodeResult)actionResult).StatusCode == HttpStatusCode.OK)
                Assert.AreEqual(HttpStatusCode.OK, ((System.Web.Http.Results.StatusCodeResult)actionResult).StatusCode);
        }
        public void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
