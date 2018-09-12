using ProjectManager.DataLayer;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ProjectManager.BusinessLayer
{
    public class ProjectManagerUserBL
    {
        //DAL Context
        ProjectManagerContext db = new ProjectManagerContext();
        /// <summary>
        /// Add New User
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();            
        }
        /// <summary>
        /// Get User by userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserById(int userId)
        {
            User u = new User();
            u = db.Users.Find(userId);
            return u;
        }
        /// <summary>
        /// Get all the users
        /// </summary>
        /// <returns></returns>
        public List<User> GetUser()
        {
            List<User> users = new List<User>();
            users = db.Users.ToList();
            return users;
        }
        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="user"></param>
        public void DeleteUser(User user)
        {
            db.Users.Attach(user);
            db.Users.Remove(user);
            db.SaveChanges();
        }
        /// <summary>
        /// Updated User
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            db.Users.AddOrUpdate(user);
            db.SaveChanges();
        }
    }
}
