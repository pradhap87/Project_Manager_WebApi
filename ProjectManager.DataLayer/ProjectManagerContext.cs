namespace ProjectManager.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectManagerContext : DbContext
    {
        public ProjectManagerContext()
            : base("name=ProjectManager_Model")
        {
        }

        public virtual DbSet<ParentTask> ParentTasks { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ParentTask>()
        //        .HasMany(e => e.Tasks)
        //        .WithOptional(e => e.ParentTask)
        //        .HasForeignKey(e => e.Parent__ID);

        //    modelBuilder.Entity<User>()
        //        .HasMany(e => e.Projects)
        //        .WithOptional(e => e.User)
        //        .HasForeignKey(e => e.Manager_Id);
        //}
        private void FixEfProviderServicesProblem()
        {
            // The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            // for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            // Make sure the provider assembly is available to the running application. 
            // See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
