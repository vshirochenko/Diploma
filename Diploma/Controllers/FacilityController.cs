using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Diploma.Models;
using Diploma.Services.AddressService;
using Diploma.Services.FacilityService;
using Ninject;

namespace Diploma.Controllers
{
    public class FacilityController : Controller
    {
        [Inject]
        public IFacilityService FacilityService { get; set; } 
        [Inject]
        public IAddressService AddressService { get; set; }

        // GET: Facilities
        public ActionResult Index()
        {
            List<Facility> facilities = FacilityService.GetFacilities().ToList();
            return View(facilities);
        }

        //[Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
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

        // Открываем форму создания нового элемента
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
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

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage =
                    "Удаление прошло неуспешно. Попробуйте повторить операцию снова или свяжитесь с администратором.";
            }
            Facility facility = FacilityService.GetFacility(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            return View(facility);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Facility facility = FacilityService.GetFacility(id);
                FacilityService.DeleteFacility(facility);
                FacilityService.SaveFacility();
            }
            catch (RetryLimitExceededException)
            {
                return RedirectToAction("Delete", new {id = id, saveChangesError = true});
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditFacilityAddress(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Address address = AddressService.GetAddress(id);
            if (address == null)
            {
                return HttpNotFound(String.Format("Элемент с id = {0} не найден!", id));
            }
            return PartialView("_EditFacilityAddress", address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFacilityAddress(Address address)
        {
            if (ModelState.IsValid)
            {
                AddressService.UpdateAddress(address);
                AddressService.SaveAddress();
                return Json(new {success = true});
            }

            return PartialView("_EditFacilityAddress", address);
        }

        [HttpGet]
        public ActionResult GoogleMap(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Address address = AddressService.GetAddress(id);
            if (address == null)
            {
                return HttpNotFound(String.Format("Элемент с id = {0} не найден!", id));
            }
            return View(address);
        }
    }
}