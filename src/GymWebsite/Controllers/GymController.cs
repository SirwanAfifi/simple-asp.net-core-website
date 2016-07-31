using GymWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GymWebsite.ViewModels;
using System.Linq;

namespace GymWebsite.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class GymController : Controller
    {
        private readonly IGymService _gymService;
        public GymController(IGymService gymService)
        {
            _gymService = gymService;
        }
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
    }
}
