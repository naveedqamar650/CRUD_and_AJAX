using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Using_AJAX_In_ASP.NET_MVC.Models;

namespace Using_AJAX_In_ASP.NET_MVC.Controllers
{
    public class StudentController : Controller
    {
        StudentContext context = new StudentContext();

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult createStudent(tbl_Student std)
        {
            context.Students.Add(std);
            context.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        [HttpPost]
        public JsonResult getStudent(string id)
        {
            List<tbl_Student> students = new List<tbl_Student>();
            students = context.Students.ToList();
            return Json(students, JsonRequestBehavior.AllowGet);
        }
    }
}