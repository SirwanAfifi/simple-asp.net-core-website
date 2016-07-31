using GymWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GymWebsite.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace GymWebsite.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class GymController : Controller
    {
        #region Dependencies
        private readonly IGymService _gymService;
        private IHostingEnvironment _environment;
        #endregion
        #region Ctor
        public GymController(IGymService gymService, IHostingEnvironment environment)
        {
            _gymService = gymService;
            _environment = environment;
        }
        #endregion
        #region API Methods
        public IEnumerable<GymViewModel> Get()
        {
            return _gymService.GetGyms().Select(p => new GymViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Address = p.Address,
                Image = $"/img/uploaded/{p.Images.FirstOrDefault(k => !k.IsCoverPhoto)?.FileName.FileName}"
            });
        }

        [HttpPost("/api/deleteImage/{imageName}")]
        public IActionResult DeleteImage(string imageName)
        {
            if (_gymService.DeleteImage(imageName))
            {
                var file = Path.Combine(_environment.WebRootPath, $"img/uploaded/{imageName}");
                System.IO.File.Delete(file);
                return Json("ok");
            }
            return Json("no");
        }
        #endregion
    }
}
