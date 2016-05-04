using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Diploma.Models;
using Diploma.Services.FacilityService;
using Ninject;

namespace Diploma.Controllers
{
    public class FacilityController : Controller
    {
        [Inject]
        public IFacilityService FacilityService { get; set; } 

        // GET: Facilities
        public ActionResult Index()
        {
            List<Facility> facilities = FacilityService.GetFacilities().ToList();
            return View(facilities);
        }

        // Открываем форму создания нового элемента
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Facility facility)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FacilityService.CreateFacility(facility);
                    FacilityService.SaveFacility();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Невозможно сохранить изменения");
            }
            return View(facility);
        }
    }
}