using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UMSS.Areas.Identity.Data;
using UMSS.Data;
using UMSS.Models;

namespace UMSS.Controllers
{
    [Authorize(Roles = "SystemAdministrator")]

    public class UserController : Controller
    {
        private readonly UserManager<UMSSUser> _userManager;
        private readonly UMSSContext _context;
        private string connectionString;

        public UserController(UserManager<UMSSUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var allUsersExceptCurrentUser = await _userManager.Users.Where(a => a.Id != currentUser.Id).ToListAsync();
            return View(allUsersExceptCurrentUser);
        }




        public async Task<IActionResult> UserList()
        {
            if (HttpContext.User.IsInRole("SystemAdministrator"))
            {
                var users = await _userManager.Users.ToListAsync();
                var userRolesViewModel = new List<UserRolesViewModel>();
                foreach (UMSSUser user in users)
                {
                    var thisViewModel = new UserRolesViewModel();

                    thisViewModel.UserId = user.Id;
                    thisViewModel.Email = user.Email;
                    thisViewModel.FirstName = user.FirstName;
                    thisViewModel.LastName = user.LastName;
                    thisViewModel.EmployeeID = user.EmployeeID;
                    thisViewModel.ProfilePicture = user.ProfilePicture;
                    thisViewModel.UserName = user.UserName;
                    thisViewModel.PhoneNumber = user.PhoneNumber;
                    userRolesViewModel.Add(thisViewModel);
                }
                return View(userRolesViewModel);
            }
            return View("User/UserList");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUser(string UserID)
        {
            var user = await _userManager.FindByIdAsync(UserID);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("ListOfRoles");
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            else
            {
                return View("NotFound");
            }
            return View("NotFound");
        }

        public async Task<ActionResult> DeleteUserd(string userId)
        {
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //get User Data from Userid
            var user = await _userManager.FindByIdAsync(userId);

            //List Logins associated with user
        
            using (var transaction = _context.Database.BeginTransaction())
            {
              
                //Delete User
                await _userManager.DeleteAsync(user);

                TempData["Message"] = "User Deleted Successfully. ";
                TempData["MessageValue"] = "1";
                //transaction.commit();
            }

            return RedirectToAction("UsersWithRoles", "ManageUsers", new { area = "", });
        }

    }
}

      
