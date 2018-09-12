namespace ProjectManager.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ParentTask
    {
        [Key]
        public int Parent_ID { get; set; }

        public string Parent_Task { get; set; }
     
    }
}
