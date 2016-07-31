using System;
using System.Collections.Generic;
using GymWebsite.Services.Interfaces;
using GymWebsite.ViewModels;
using System.Linq;

namespace GymWebsite.Services.Concreates
{
    public class GymService : IGymService
    {
        private readonly List<Gym> _gyms;
        public GymService()
        {
            _gyms = new List<Gym>();
        }
        public void AddGym(Gym model)
        {
            _gyms.Add(model);
        }

        public void DeleteGym(Guid gymId)
        {
            var item = _gyms.Find(p => p.Id == gymId);
            _gyms.Remove(item);
        }

        public bool DeleteImage(string imageName)
        {
            var ii = false;
            // جستجو درون تصاویر و سپس حذف تصویر
            _gyms.ForEach(p =>
            {
                if (p.Images.All(i => i.FileName.FileName != imageName)) return;
                {
                    var img = p.Images.FirstOrDefault(i => i.FileName.FileName == imageName);
                    p.Images.Remove(img);
                    ii = true;
                }
            });
            return ii;
        }

        public Gym GetGymById(Guid gymId)
        {
            return _gyms.Find(p => p.Id == gymId);
        }

        public IList<Gym> GetGyms()
        {
            return _gyms;
        }

        public void UpdateGym(Gym model)
        {
            var item = _gyms.Find(p => p.Id == model.Id);
            item.Title = model.Title;
            item.Address = model.Address;
            if (model.Images != null)
            {
                foreach (var img in model.Images)
                {
                    item.Images.Add(img);
                }
            }
        }
    }
}
