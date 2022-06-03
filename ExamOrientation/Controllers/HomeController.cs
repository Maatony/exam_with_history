using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamOrientation.Services;
using ExamOrientation.Models;
using ExamOrientation.Interfaces;
using ExamOrientation.Data;
using ExamOrientation.ViewModels; 

namespace ExamOrientation.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IReportService reportService;

        // Dependency injection of services
        public HomeController(IUserService usrSrv, IReportService rptSrv)
        {
            userService = usrSrv;
            reportService = rptSrv;
        }

        // First endpoint - open Add Report via GET
        [HttpGet("")]
        public IActionResult Index()
        {
            List<User> users= userService.GetUsers();
            return View("Index", new VMAddReport() { Users = users , Issue = new List<string>()});
        }

        // Second endpoint - Add Report via POST
        [HttpPost("")]
        public IActionResult AddReport(Report report)
        {
            VMAddReport vMAddReport = reportService.AddReport(report);
            List<User> users = userService.GetUsers();
            
            return View("Index", vMAddReport);
        }

        // Third endpoint - open List of Reports via GET
        [HttpGet("list")]
        public IActionResult GetList()
        {
            return View("ReportList", new List<Report>());
        }

        // Fourth endpoint - Delete/Complete Report via POST using secret - no View created (should be rather API request?)
        [HttpDelete("complete/{id=-1}")]
        public IActionResult AddReport([FromRoute] int id, [FromBody] SecretFromBody secret)
        {
            int statusCode = reportService.TryToCompleteReport(id, secret);
            return StatusCode(statusCode);
        }


        // Extra endpoint - open adduser page via GET
        [HttpGet("addUser")]
        public IActionResult addUserOpen()
        {
            List<User> users = userService.GetUsers();
            return View("AddUser", users);
        }

        // Extra endpoint - add adduser page via POST
        [HttpPost("addUser")]
        public IActionResult addUser(User user)
        {
            userService.AddUserToDB(user);
            return RedirectToAction("AddUserOpen");
        }
    }
}
