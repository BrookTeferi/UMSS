using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UMSS.Areas.Identity.Data;
using UMSS.Data;
using UMSS.Models;

namespace UMSS.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<UMSSUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UMSSContext _context;
        public HomeController(UserManager<UMSSUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

       

    
      

        public IActionResult Index()
        {
            DashboardViewModel dashboard = new DashboardViewModel();
            dashboard.User_count = 0;
            dashboard.Role_count =0;
            dashboard.Account_count = 0;
            dashboard.Sample_count = 0;
          
            return View(dashboard);
        }

    
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
