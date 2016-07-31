using System;
using System.Collections.Generic;
using GymWebsite.Services.Interfaces;
using GymWebsite.ViewModels;

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
