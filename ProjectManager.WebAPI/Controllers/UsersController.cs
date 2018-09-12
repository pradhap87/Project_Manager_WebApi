#region Header
// Module               : Web Api User controller
// Version              : 1.0
// Author               : Prathap (436812)
// Date                 : 07-Sep-2018
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

#region UserController

namespace ProjectManager.WebAPI.Controllers
{    
    public class UsersController : ApiController
    {
        ProjectManagerUserBL usertBL = new ProjectManagerUserBL();
                
        /// <summary>
        /// Get all the Users 
        /// </summary>
        /// <returns>Users</returns>
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            List<User> users = new List<User>();
            try
            {
                users = usertBL.GetUser();
            }         
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(users);
        }

        // GET api/<controller>/5
        /// <summary>
        /// Get user baased on user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            User user = new User();
            try
            {
                user = usertBL.GetUserById(id);
                if (user != null)
                    return Ok(user);
                else
                    return BadRequest("No User found with Id as :"+id.ToString());
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        
        /// <summary>
        /// Add New User
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult AddUser(String firstName, String lastName, int employeeId)
        {
            User user = new User();
            try
            {
                user.First_Name = firstName;
                user.Last_Name = lastName;
                user.Employee_ID = employeeId;
                usertBL.AddUser(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return StatusCode(HttpStatusCode.Created);
        }

        /// <summary>
        /// Update existing user information
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult UpdatUser(User user)
        {
            try
            {
                usertBL.UpdateUser(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return StatusCode(HttpStatusCode.OK);
        }

        /// <summary>
        /// Delete existing user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult DeleteUser(User user)
        {
            try
            {
                usertBL.DeleteUser(user);
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