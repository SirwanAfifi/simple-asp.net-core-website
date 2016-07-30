using GymWebsite.Services.Interfaces;
using GymWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GymWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGymService _gymService;
        public HomeController(IGymService gymService)
        {
            _gymService = gymService;
        }
        public IActionResult List()
        {
            var list = _gymService.GetGyms();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Gym model)
        {
            _gymService.AddGym(model);

            return RedirectToAction("List");
        }
    }
}