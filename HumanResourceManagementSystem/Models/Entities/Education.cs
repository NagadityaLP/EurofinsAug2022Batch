using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HumanResourceManagementSystem.Models.Entities
{
    public class Education
    {
        public int EducationID { get; set; }
        [Required]
        [MaxLength(30)]
        public string BachelorDegree { get; set; }
        [Required]
        public int MarksBachelorDegree { get; set; }
        [Required]
        [MaxLength(30)]
        public string MasterDegree { get; set; }
        [Required]
        public int MarksMasterDegree { get; set; }
        [MaxLength(100)]
        public string AdditionalCourse { get; set; }

    }
}