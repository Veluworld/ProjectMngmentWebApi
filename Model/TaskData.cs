using ProjectData_API.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectDataAPI.Models
{
    public class TaskData
    {
        [Key]
        public int TaskId { get; set; }
        [Required(ErrorMessage = "Team Member Name is Required !!!")]
        public string MemberName { get; set; }
        [Required(ErrorMessage = "Task Name is Required !!!")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "MemberId is Required !!!")]        
        public int MemberId { get; set; }
        [Required(ErrorMessage = "Deliverables is Required !!!")]
        public string Deliverables { get; set; }
        [Required(ErrorMessage = "Start date is Required !!!")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End date is Required !!!")]
        public DateTime EndDate { get; set; }
       
        
    }
}