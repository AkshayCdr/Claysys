using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatchWorld.Models;
using WatchWorld.Repository;

namespace WatchWorld.Controllers
{
    public class RegistrationController : Controller
    {
        RegistrationRepository registrationRepository = new RegistrationRepository();
        // GET: Registration
        public ActionResult List()
        {
            var data = registrationRepository.GetUsers();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Registration registration)
        {
            if (registrationRepository.InsertUser(registration))
            {
                TempData["InsertMsg"] = "<script>alert('User saved sucessfully.....')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErrorMsg"] = "<script>alert('Error')</script>";

            }
            return View();
            
        }

        public ActionResult Edit(int id)
        {
            var data = registrationRepository.GetUsers().Find(a => a.Id == id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Registration registration)
        {
            if (registrationRepository.UpdateUser(registration))
            {
                TempData["UpdateMsg"] = "<script>alert('User updatedsucessfully.....')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["UpdateErrorMsg"] = "<script>alert('Error')</script>";

            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            int result = registrationRepository.DeleteUser(id);
            if (result > 0)
            {
                TempData["DeleteMsg"] = "<script>alert('User Deleted sucessfully.....')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["DeleteErrorMsg"] = "<script>alert('Error Deleting')</script>";

            }
            return View();
        }
    }
}