using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace GymWebsite.ViewModels
{
    public class Gym
    {
        public Gym()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public List<Image> Images { get; set; }
    }

    public class Image
    {
        public IFormFile FileName { get; set; }
        public int Order { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsCoverPhoto { get; set; }
    }
}
