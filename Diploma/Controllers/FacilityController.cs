using System;
using System.Collections.Generic;
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
        public ActionResult Create()
        {
            return View();
        }
    }
}