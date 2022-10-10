using CRUDApplication.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDApplication.Controllers
{
    public class StudentController : Controller
    {
        db_testEntities dBobj = new db_testEntities();

        // GET: Student
        public ActionResult Student(tbl_Student obj)
        {
                return View(obj);
        }

        [HttpPost]
        public ActionResult AddStudent(tbl_Student modelData)
        {
            if (ModelState.IsValid)
            {
                tbl_Student obj = new tbl_Student();

                obj.ID = modelData.ID;

                obj.Name = modelData.Name;
                obj.Fname = modelData.Fname;
                obj.Email = modelData.Email;
                obj.Mobile = modelData.Mobile;
                obj.Description = modelData.Description;

                if (modelData.ID > 0)
                {
                    dBobj.Entry(obj).State = EntityState.Modified;
                    dBobj.SaveChanges();
                }
                else
                {
                    dBobj.tbl_Student.Add(obj);
                    dBobj.SaveChanges();
                }
                ModelState.Clear();
            }

            return View("Student");
        }

        public ActionResult StudentList()
        {
            var result = dBobj.tbl_Student.ToList();
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            var res = dBobj.tbl_Student.Where(x => x.ID == id).First();
            dBobj.tbl_Student.Remove(res);
            dBobj.SaveChanges();

            var list = dBobj.tbl_Student.ToList();

            return View("StudentList", list);
        }
    }
}