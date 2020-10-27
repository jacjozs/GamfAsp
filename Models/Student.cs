using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GAMF.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Display(Name ="Családnév")]
        [Required(ErrorMessage ="Családnév kitöltése közelező")]
        public string LastName { get; set; }
        [Display(Name = "Keresztnév")]
        [Required(ErrorMessage = "Keresztnév kitöltése közelező")]
        public string FirstMidName { get; set; }
        [Display(Name = "Első jelentkezés")]
        [Required(ErrorMessage = "Első jelentkezés dátuma kitöltése közelező")]
        public DateTime EnrollmentDate { get; set; }
        [Display(Name = "Jelentkezések")]
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
