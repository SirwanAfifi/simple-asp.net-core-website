using System;
using System.Collections.Generic;

namespace GymWebsite.ViewModels
{
    /// <summary>
    /// ویومدل نمایش لیست باشگاه‌ها
    /// </summary>
    public class GymViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
    }
}
