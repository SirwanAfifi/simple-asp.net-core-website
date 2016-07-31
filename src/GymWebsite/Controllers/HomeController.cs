﻿using GymWebsite.Services.Interfaces;
using GymWebsite.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace GymWebsite.Controllers
{
    public class HomeController : Controller
    {
        #region Dependencies
        private readonly IGymService _gymService;
        private IHostingEnvironment _environment;
        #endregion
        #region Ctor
        public HomeController(IGymService gymService, IHostingEnvironment environment)
        {
            _gymService = gymService;
            _environment = environment;
        }
        #endregion
        #region Action Methods
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

            UploadFile(model);

            return RedirectToAction("List");
        }
        public IActionResult Details(Guid id)
        {
            var item = _gymService.GetGymById(id);
            return View(item);
        }

        public IActionResult Edit(Guid id)
        {
            var item = _gymService.GetGymById(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Gym model)
        {
            _gymService.UpdateGym(model);

            UploadFile(model);

            return RedirectToAction("List");
        }
        #endregion
        #region Helpers
        private void UploadFile(Gym model)
        {
            // Uploading a new file
            var uploads = Path.Combine(_environment.WebRootPath, "img/uploaded");
            if (model.Images != null)
            {
                foreach (var file in model.Images)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName.FileName), FileMode.Create))
                    {
                        file.FileName.CopyTo(fileStream);
                    }
                }
            }
        }
        #endregion
    }
}