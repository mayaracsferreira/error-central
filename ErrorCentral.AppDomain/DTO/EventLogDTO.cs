using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErrorCentral.AppDomain.DTO
{
   public class EventLogDTO
    {

        [Required]
        public int EventID { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string CollectedBy { get; set; }

        [Required]
        public string Log { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string Environment { get; set; }

        [Required]
        public bool Archived { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

    }
}
