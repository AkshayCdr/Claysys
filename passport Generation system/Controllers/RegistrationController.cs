using PassportGenerator.Models;
using PassportGenerator.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassportGenerator.Controllers
{
    public class RegistrationController : Controller
    {
        RegistrationRepository registrationRepository = new RegistrationRepository();

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
            if (ModelState.IsValid)
            {
                if (registrationRepository.InsertUser(registration))
                {
                    TempData["InsertMsg"] = "<script>alert('User saved successfully.')</script>";
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["InsertErrorMsg"] = "<script>alert('Error')</script>";
                }
            }


            return View(registration);
        }

        public ActionResult Edit(int id)
        {
            var data = registrationRepository.GetUsers().Find(a => a.Id == id);
            if (data != null)
            {
                data.Dob = data.Dob.Date;
                return View(data);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(Registration registration)
        {
            if (ModelState.IsValid)
            {
                if (registrationRepository.UpdateUser(registration))
                {
                    TempData["UpdateMsg"] = "<script>alert('User updated successfully.')</script>";
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["UpdateErrorMsg"] = "<script>alert('Error')</script>";
                }
            }
            return View(registration);
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