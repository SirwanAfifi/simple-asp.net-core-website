namespace GymWebsite.ViewModels
{
    /// <summary>
    /// ویومدل نمایش تصاویر باشگاه
    /// </summary>
    public class ImageViewModel
    {
        public string FileName { get; set; }
        public int Order { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsCoverPhoto { get; set; }
    }
}
