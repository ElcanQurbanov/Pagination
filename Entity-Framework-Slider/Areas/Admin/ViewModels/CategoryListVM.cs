using Entity_Framework_Slider.Models;

namespace Entity_Framework_Slider.Areas.Admin.ViewModels
{
    public class CategoryListVM
    {
        //[Required(ErrorMessage = "Don't be empty")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
    }
}
