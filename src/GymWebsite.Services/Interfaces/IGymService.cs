using GymWebsite.ViewModels;
using System;
using System.Collections.Generic;

namespace GymWebsite.Services.Interfaces
{
    public interface IGymService
    {
        /// <summary>
        /// افزودن یک باشگاه جدید
        /// </summary>
        /// <param name="model">مدل دریافتی از کاربر</param>
        void AddGym(Gym model);
        /// <summary>
        /// حذف یک باشگاه
        /// </summary>
        /// <param name="gymId">آی‌دی باشگاه</param>
        void DeleteGym(Guid gymId);
        /// <summary>
        /// ویرایش یک باشگاه
        /// </summary>
        /// <param name="model">مدل دریافتی از کاربر</param>
        void UpdateGym(Gym model);
        /// <summary>
        /// دریافت یک باشگاه
        /// </summary>
        /// <param name="gymId">آی‌دی دریافتی از کاربر</param>
        /// <returns>باشگاه</returns>
        Gym GetGymById(Guid gymId);
        /// <summary>
        /// دریافت تمامی باشگاه‌ها
        /// </summary>
        /// <returns>لیست باشگاه‌ها</returns>
        IList<Gym> GetGyms();
    }
}
