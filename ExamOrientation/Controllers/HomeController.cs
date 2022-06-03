using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamOrientation.Services;
using ExamOrientation.Models;

namespace ExamOrientation.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IXXXService _xxxService;

        // Dependency injection of XXX service
        public HomeController(IXXXService xxxSrv)
        {
            _xxxService = xxxSrv;
        }

        // First endpoint
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
