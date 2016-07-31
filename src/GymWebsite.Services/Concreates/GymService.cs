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
            bool ii = false;
            _gyms.ForEach(p => {
                if (p.Images.Any(i => i.FileName.FileName == imageName))
                {
                    var img = p.Images.FirstOrDefault(i => i.FileName.FileName == imageName);
                    p.Images.Remove(img);
                    ii = true;
                    return;
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
        }
    }
}
