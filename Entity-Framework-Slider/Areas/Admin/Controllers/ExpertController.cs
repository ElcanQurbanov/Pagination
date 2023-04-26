using Entity_Framework_Slider.Data;
using Entity_Framework_Slider.Services;
using Entity_Framework_Slider.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework_Slider.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExpertController : Controller
    {
        private readonly IExpertService _expertService;
        private readonly AppDbContext _context;
        public ExpertController(IExpertService expertService, AppDbContext context)
        {
            _expertService = expertService;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _expertService.GetHeader());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
