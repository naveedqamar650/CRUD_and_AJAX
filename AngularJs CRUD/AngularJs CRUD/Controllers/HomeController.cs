using AngularJs_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJs_CRUD.Controllers
{
    public class HomeController : Controller
    {
        StudentContext context = new StudentContext();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(tbl_Student std)
        {
            context.Students.Add(std);
            context.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        public JsonResult GetRecord(string id)
        {
            List<tbl_Student> students = new List<tbl_Student>();
            students = context.Students.ToList();
            return Json(students, JsonRequestBehavior.AllowGet);
        }
        public string Update(tbl_Student std)
        {
            var result = context.Students.Where(u => u.ID == std.ID).First();
            result.Name = std.Name;
            result.Fname = std.Fname;
            result.Mobile = std.Mobile;
            result.Email = std.Email;
            result.Description = std.Description;
            context.SaveChanges();

            return ("Updated");
        }
        public string Delete(int id)
        {
            var result = context.Students.First(u => u.ID == id);
            context.Students.Remove(result);
            context.SaveChanges();

            return ("Deleted");
        }
    }
}