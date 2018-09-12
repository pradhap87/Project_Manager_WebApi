namespace ProjectManager.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Task
    {
        [Key]
        public int Task_ID { get; set; }

        [Column("Parent _ID")]
        public int? Parent__ID { get; set; }

        public int? Project_ID { get; set; }

        [Column("Task")]
        public string Task1 { get; set; }

        [Column("Start Date", TypeName = "date")]
        public DateTime? Start_Date { get; set; }

        [Column("End Date", TypeName = "date")]
        public DateTime? End_Date { get; set; }

        public int? Priority { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
        
    }
}
