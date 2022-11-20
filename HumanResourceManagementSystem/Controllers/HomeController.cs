using HumanResourceManagementSystem.Models.Data;
using HumanResourceManagementSystem.Models.Entities;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace HumanResourceManagementSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IHRDBRepository repo = null;

        public HomeController(IHRDBRepository repo)
        {
            this.repo = repo;
        }

        //[Authorize(Roles = "HRM")]
        public ActionResult Index(string data = null)
        {
            List<PersonalInformation>  infoList = repo.GetAll();
            if (data == null)
                infoList = repo.GetAll();
            else
            {
                infoList = (from p in repo.GetAll()
                                    where p.FirstName.ToLower().Contains(data.ToLower()) ||
                                    p.LastName.ToLower().Contains(data.ToLower())
                                    select p).ToList();
            }
            return View(infoList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "HRM")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "HRM")]
        [HttpPost]
        public ActionResult Create(PersonalInformation info)
        {
            if (!ModelState.IsValid)
                return View("Create");
            repo.Save(info);
            TempData["Message"] = $"Personal information saved successfully";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "HRM")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            PersonalInformation employeeToEdit = repo.GetPersonalInfo(id);
            return View(employeeToEdit);
        }

        [Authorize(Roles = "HRM")]
        [HttpPost]
        public ActionResult Edit(PersonalInformation info)
        {
            if (!ModelState.IsValid)
                return View();
            repo.Update(info);
            var name = info.FirstName + info.MiddleName + info.LastName;
            TempData["Message"] = $"Personal information of {name}  is Successfully Modified";
            return RedirectToAction("Index");
        }

        public ActionResult Display(int id)
        {
            return View(repo.GetPersonalInfo(id));
        }

        
    }
}