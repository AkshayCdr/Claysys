using Newtonsoft.Json;
using PassportGenerator.Models;
using PassportGenerator.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassportGenerator.Controllers
{
    public class HomeController : Controller
    {
        StudentRepository studentRepository = new StudentRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        //[HttpPost]
        //public JsonResult AddStudent(StudentModel student)
        //{
        //    studentRepository.InsertIntoStudent(student);

        //    return Json(true, JsonRequestBehavior.AllowGet);
        //}


        //[HttpPost]
        //public JsonResult AddStudent(StudentModel student)
        //{
        //    return Json(true, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult AddStudent(StudentModel student)
        {
            return View("index"); 
        }




    }
}