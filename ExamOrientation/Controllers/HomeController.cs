﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamOrientation.Services;
using ExamOrientation.Models;
using ExamOrientation.Interfaces;

namespace ExamOrientation.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IReportService reportService;

        // Dependency injection of XXX service
        public HomeController(IUserService usrSrv, IReportService rptSrv)
        {
            userService = usrSrv;
            reportService = rptSrv;
        }

        // First endpoint
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
