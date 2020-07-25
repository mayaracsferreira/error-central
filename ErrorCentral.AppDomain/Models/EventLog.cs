using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ErrorCentral.AppDomain.Models
{
    [Table("EventLog")]
    public class EventLog
    {
        [Key]
        [Column("ID", TypeName = "int")]
        public int EventID { get; set; }

        [Column("Level", TypeName = "nvarchar(50)"), Required]
        public string Level { get; set; }

        [Column("Title", TypeName = "nvarchar(255)"), Required]

        public string Title { get; set; }
        [Column("Collected", TypeName = "nvarchar(255)"), Required]
        public string CollectedBy { get; set; }

        [Column("Log", TypeName = "nvarchar(255)"), Required]
        public string Log { get; set; }

        [Column("Description", TypeName = "nvarchar(500)"), Required]
        public string Description { get; set; }

        [Column("Origin", TypeName = "nvarchar(255)"), Required]
        public string Origin { get; set; }

        [Column("Environment", TypeName = "nvarchar(255)"), Required]
        public string Environment { get; set; }

        [Column("Archived", TypeName = "boolean"), Required]
        public bool Archived { get; set; }

        [Column("CreatedDate", TypeName = "datetime"), Required]
        public DateTime CreatedDate { get; set; }
    }
}
