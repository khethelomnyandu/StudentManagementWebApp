using Microsoft.AspNetCore.Mvc;
using StudentManagementWebApp.Models;
using System.Linq;

namespace StudentManagementWebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // Display all students
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // Add a new student
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Delete a student
        [HttpPost]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Edit a student (from JS)
        [HttpPost]
        public IActionResult EditStudent([FromBody] Student editedStudent)
        {
            var student = _context.Students.Find(editedStudent.Id);
            if (student != null)
            {
                student.Name = editedStudent.Name;
                student.StudentNumber = editedStudent.StudentNumber;
                student.Course = editedStudent.Course;
                student.Age = editedStudent.Age;
                _context.SaveChanges();
            }
            return Json(new { success = true });
        }
    }
}