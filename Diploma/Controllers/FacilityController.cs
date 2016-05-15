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
        [ValidateAntiForgeryToken]
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

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facility facility = FacilityService.GetFacility(id);
            if (facility == null)
            {
                return HttpNotFound(String.Format("Элемент с id = {0} не найден!", id));
            }
            return View(facility);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Facility facilityToUpdate)
        {
            if (facilityToUpdate == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                FacilityService.UpdateFacility(facilityToUpdate);
                FacilityService.SaveFacility();

                return RedirectToAction("Index");
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Невозможно сохранить изменения");
            }
            return View(facilityToUpdate);
        }
    }
}