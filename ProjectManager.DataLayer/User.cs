namespace ProjectManager.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        public int User_ID { get; set; }

        [Column("First Name")]
        public string First_Name { get; set; }

        [Column("Last Name")]
        public string Last_Name { get; set; }

        public int? Employee_ID { get; set; }

    }
}
