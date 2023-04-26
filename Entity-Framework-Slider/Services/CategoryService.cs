using Entity_Framework_Slider.Data;
using Entity_Framework_Slider.Models;
using Entity_Framework_Slider.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_Slider.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<int> GetCountAsync() => await _context.Categories.CountAsync();
        
        public async Task<List<Category>> GetPaginatedDatas(int page, int take) => await _context.Categories.Skip((page * take)- take).Take(5).Include(m=>m.Products).ToListAsync();
        
    }
}
