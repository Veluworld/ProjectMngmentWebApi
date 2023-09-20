using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectData_API.Model
{
    public class ProjectData
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Team Member Name is Required !!!")]
        public string TeamMemberName { get; set; }
        [Required]
        [Range(4, 10, ErrorMessage = "Experience must be between 4 to 10")]
        public string Experience { get; set; }

        [Required(ErrorMessage = "Skill set is Required !!!")]
        [SkillsetValidateAttribute]
        public string SkillSet { get; set; }
        [Required(ErrorMessage = "Description is Required !!!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Start date is Required !!!")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End date is Required !!!")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Allocation Percentage is Required !!!")]
        public int AllocationPercentage { get; set; }

    }

    public class SkillsetValidateAttribute : ValidationAttribute
    {             

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ////ProjectData _prj = new ProjectData();
            var skillset = value.ToString();
            int count = Regex.Matches(skillset, ",").Count;                   
            
            if (count < 2) {
                return new ValidationResult(this.FormatErrorMessage("Atleast 3 Skillset is mandatory(Comma sepearated !!!"));
            }

            return null;
        }
    }

    //public class DateValidateAttribute : ValidationAttribute
    //{
    //    DateTime _endDate;
    //    public DateValidate(DateTime enddate)
    //    { 
    //        this._endDate = enddate;
    //    }
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        ////ProjectData _prj = new ProjectData();
    //        var skillset = value.ToString();
    //        int count = Regex.Matches(skillset, ",").Count;

    //        if (count < 2)
    //        {
    //            return new ValidationResult(this.FormatErrorMessage("Atleast 3 Skillset is mandatory(Comma sepearated !!!"));
    //        }

    //        return null;
    //    }
    //}
}