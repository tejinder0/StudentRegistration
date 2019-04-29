using StudentRegistrationMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationMVCProject.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<StudentViewModel> stList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("StudentRegistrations").Result;
            stList = response.Content.ReadAsAsync<IEnumerable<StudentViewModel>>().Result;
            return View(stList);
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new StudentViewModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("StudentRegistrations/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<StudentViewModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(StudentViewModel studentViewModel)
        {
            if (studentViewModel.ID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("StudentRegistrations", studentViewModel).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("StudentRegistrations/" + studentViewModel.ID, studentViewModel).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("StudentRegistrations/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}