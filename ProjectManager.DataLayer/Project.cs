namespace ProjectManager.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Project
    {        

        [Key]
        public int Project_ID { get; set; }

        [Column("Project")]
        public string Project1 { get; set; }

        [Column("Start Date", TypeName = "date")]
        public DateTime? Start_Date { get; set; }

        [Column("End Date", TypeName = "date")]
        public DateTime? End_Date { get; set; }

        public int? Manager_Id { get; set; }

        public int? Priority { get; set; }
                

    }
}
