using Entity_Framework_Slider.Areas.Admin.ViewModels;
using Entity_Framework_Slider.Helpers;
using Entity_Framework_Slider.Models;
using Entity_Framework_Slider.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework_Slider.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index(int page = 1, int take = 4)
        {
            List<Product> products = await _productService.GetPaginatedDatas(page,take);

            List<ProductListVM> mappedDatas = GetMappedDatas(products);

            int pageCount = await GetPageCountAsync(take);

            Paginate<ProductListVM> paginatedDatas = new Paginate<ProductListVM>(mappedDatas, page, pageCount); 

            return View(paginatedDatas);
        }

        private async Task<int> GetPageCountAsync(int take)
        {
            var productCount = await _productService.GetCountAsync();
            return (int) Math.Ceiling((decimal)productCount / take);
        }

        private List<ProductListVM> GetMappedDatas(List<Product> products)
        {
            List<ProductListVM> mappedDatas = new();

            foreach (var product in products)
            {
                ProductListVM productVM = new()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Count = product.Count,
                    CategoryName = product.Category.Name,
                    MainImage = product.Images.Where(m => m.IsMain).FirstOrDefault()?.Image
                };
                mappedDatas.Add(productVM);
            }

            return mappedDatas;
        }

    }
}
