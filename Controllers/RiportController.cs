using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GAMF.Data;
using GAMF.Models;
using GAMF.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace GAMF.Controllers
{
    public class RiportController : Controller
    {
        private readonly GAMFDbContext _context;

        public RiportController(GAMFDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StudentCredits()
        {
            //Nem szép de megy
            IQueryable<StudentCreditsVM> credits =
                from student in _context.Students
                join enrollment in _context.Enrollments on student.Id equals enrollment.StudentId
                join course in _context.Courses on enrollment.CourseId equals course.CourseId
                select new StudentCreditsVM()
                {
                    StudentName = $"{student.LastName} {student.FirstMidName}",
                    Credits = student.Enrollments.Where(e => e.Grade != Grade.F).Sum(e => e.Course.Credits),
                    FullCredits = student.Enrollments.Sum(e => e.Course.Credits)
                };
            List<StudentCreditsVM> result = new List<StudentCreditsVM>();
            foreach (var vm in credits.ToList().GroupBy(s => s.StudentName).OrderBy(s => s.Key))
            {
                result.Add(vm.First());
            }
            return View(result);
        }
    }
}
