using Entity_Framework_Slider.Models;

namespace Entity_Framework_Slider.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();
        Task<List<Category>> GetPaginatedDatas(int page, int take);
        Task<int> GetCountAsync();
    }
}
