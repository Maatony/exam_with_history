using Microsoft.AspNetCore.Mvc;
using ExamOrientation.Interfaces;
using ExamOrientation.Services;
using ExamOrientation.Models;
using ExamOrientation.Data;

namespace ExamOrientation.Controllers
{
    [Route("api")]
    public class RESTController : Controller
    {
        private readonly IUserService userService;
        private readonly IReportService reportService;

        // Dependency injection of services
        public RESTController(IUserService usrSrv, IReportService rptSrv)
        {
            userService = usrSrv;
            reportService = rptSrv;
        }


        [HttpGet("reports")]
        public IActionResult GetReports([FromRoute] ReportAPI request)
        {
            return View();
        }
    }
}
